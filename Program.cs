using System;

namespace Geometry
{
    public class Triangle
    {
        
        protected (double X, double Y) _vertexA;
        protected (double X, double Y) _vertexB;
        protected (double X, double Y) _vertexC;

        
        public void SetVertices((double X, double Y) vertexA, (double X, double Y) vertexB, (double X, double Y) vertexC)
        {
            _vertexA = vertexA;
            _vertexB = vertexB;
            _vertexC = vertexC;
        }

        
        public void DisplayVertices()
        {
            Console.WriteLine($"Vertex A: ({_vertexA.X}, {_vertexA.Y})");
            Console.WriteLine($"Vertex B: ({_vertexB.X}, {_vertexB.Y})");
            Console.WriteLine($"Vertex C: ({_vertexC.X}, {_vertexC.Y})");
        }

        
        public double CalculateArea()
        {
            return Math.Abs((_vertexA.X * (_vertexB.Y - _vertexC.Y) +
                             _vertexB.X * (_vertexC.Y - _vertexA.Y) +
                             _vertexC.X * (_vertexA.Y - _vertexB.Y)) / 2.0);
        }
    }

    public class Quadrilateral : Triangle
    {
        
        private (double X, double Y) _vertexD;

        
        public void SetVertices((double X, double Y) vertexA, (double X, double Y) vertexB, (double X, double Y) vertexC, (double X, double Y) vertexD)
        {
            base.SetVertices(vertexA, vertexB, vertexC);
            _vertexD = vertexD;
        }

        
        public new void DisplayVertices()
        {
            base.DisplayVertices();
            Console.WriteLine($"Vertex D: ({_vertexD.X}, {_vertexD.Y})");
        }

        
        public new double CalculateArea()
        {
            
            var triangle1Area = base.CalculateArea();
            var triangle2Area = Math.Abs((base._vertexC.X * (base._vertexA.Y - _vertexD.Y) +
                                          _vertexD.X * (base._vertexC.Y - base._vertexA.Y) +
                                          base._vertexA.X * (_vertexD.Y - base._vertexC.Y)) / 2.0);
            return triangle1Area + triangle2Area;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            var triangle = new Triangle();
            triangle.SetVertices((0, 0), (4, 0), (0, 3));
            Console.WriteLine("Triangle:");
            triangle.DisplayVertices();
            Console.WriteLine($"Area: {triangle.CalculateArea()}\n");

            
            var quadrilateral = new Quadrilateral();
            quadrilateral.SetVertices((0, 0), (4, 0), (4, 3), (0, 3));
            Console.WriteLine("Quadrilateral:");
            quadrilateral.DisplayVertices();
            Console.WriteLine($"Area: {quadrilateral.CalculateArea()}");
        }
    }
}
