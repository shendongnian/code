    using MathNet.Numerics.LinearAlgebra.Double;
    using System.Linq;
    
    ...
    var myarray = new double[3, 4]
    {
        { 1, 2, 3, 4},
        { 5, 6, 7, 8},
        { 9, 10, 11, 12}
    };
    
    var factors = new double[4] { 0.5, 0.4, 0, 0.8 };
    
    var matrix1 = Matrix.Build
        .DenseOfArray(myarray);
    var matrix2 = Matrix.Build
        .DenseOfRows(Enumerable.Repeat(factors, matrix1.RowCount));
    
    var res = matrix1.PointwiseMultiply(matrix2).ToArray();
