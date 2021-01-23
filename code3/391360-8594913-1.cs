    using MathNet.Numerics.LinearAlgebra;
    using System;
    using MathNet.Numerics.LinearAlgebra;
    namespace StackOverflow.Examples
    {
    public class PolynomialRegression
    {
        readonly Vector _xData;
        readonly Vector _yData;
        readonly Vector _coef;
        readonly int _order;
        public PolynomialRegression(Vector xData, Vector yData, int order)
        {
            if (xData.Length != yData.Length)
            {
                throw new IndexOutOfRangeException();
            }
            _xData = xData;
            _yData = yData;
            _order = order;
            var n = xData.Length;
            var a = new Matrix(n, order + 1);
            for (var i = 0; i < n; i++)
                a.SetRowVector(VandermondeRow(xData[i]), i);
            // Least Squares |y=A(x)*c| ...  tr(A)*y = tr(A)*A*c  ...  inv(tr(A)*A)*tr(A)*y = c
            // http://en.wikipedia.org/wiki/Total_least_squares
            var at = Matrix.Transpose(a);
            var y2 = new Matrix(yData, n);
            _coef = (at * a).Solve(at * y2).GetColumnVector(0);
        }
        Vector VandermondeRow(double x)
        {
            var row = new double[_order + 1];
            for (var i = 0; i <= _order; i++)
                row[i] = Math.Pow(x, i);
            return new Vector(row);
        }
        public double Fit(double x)
        {
            return Vector.ScalarProduct(VandermondeRow(x), _coef);
        }
        public int Order { get { return _order; } }
        public Vector Coefficients { get { return _coef; } }
        public Vector XData { get { return _xData; } }
        public Vector YData { get { return _yData; } }
    }
    }
