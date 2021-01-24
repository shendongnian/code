    Matrix<double> M = Matrix<double>.Build.DenseOfArray(new double[,]
    {
        { 1, 2 },
        { 3, 6 }
    });
    Vector<double> V = Vector<double>.Build.DenseOfArray(new double[] { 3, 4 });
    Vector<double> MV = M * V;
    Vector<double> VM = V * M;
    Console.WriteLine($"M {M}");
    Console.WriteLine($"V {V}");
    Console.WriteLine($"M*V {MV}");
    Console.WriteLine($"V*M {VM}");
