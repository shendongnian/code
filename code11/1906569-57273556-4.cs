    using MathNet.Numerics.LinearAlgebra.Double;
    // ...
    var matrix = DenseMatrix.Create(2, 2, 0);
    Console.WriteLine(matrix);
    matrix[1, 1] = 1;
    Console.WriteLine(matrix);
