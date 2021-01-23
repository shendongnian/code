    using MathNet.Numerics.LinearAlgebra;
    class Program
    {
        static void Main(string[] args)
        {
            Vector x_data = new Vector(new double[] { 0, 1, 2, 3, 4 });
            Vector y_data = new Vector(new double[] { 1.0, 1.4, 1.6, 1.3, 0.9 });
            var poly = new PolynomialRegression(x_data, y_data, 2);
            Console.WriteLine("{0,6}{1,9}", "x", "y");
            for (int i = 0; i < 10; i++)
            {
                double x = (i * 0.5);
                double y = poly.Fit(x);
                Console.WriteLine("{0,6:F2}{1,9:F4}", x, y);
            }
        }
    }
