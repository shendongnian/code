    var column1 = new double[] { 1, 2, 3, 4, 5 };
    var column2 = new double[] { 5, 3, 3, 2, 1 };
    var column3 = new double[] { 3, 4, 4, 5, 2 };
    var matrix = Matrix<double>.Build.DenseOfColumns(new[] { column1, column2, column3 });
    Console.WriteLine(matrix);
