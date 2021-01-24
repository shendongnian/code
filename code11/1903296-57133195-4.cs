    using MathNet.Numerics.LinearAlgebra;
    // ...
    double[][] biglist = new double[3][];
    biglist[0] = new double[] { 1, 2, 3, 4, 5 };
    biglist[1] = new double[] { 5, 3, 3, 2, 1 };
    biglist[2] = new double[] { 3, 4, 4, 5, 2 };
    Matrix<double> matrix = Matrix<double>.Build.DenseOfColumns(biglist);
    Console.WriteLine(matrix);
