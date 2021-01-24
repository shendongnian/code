    const int height = 8;
    const int width = 7;
    var matrix = DenseMatrix.OfArray(new double[height, width]
    {
        { 1, 0, 0, 0, 0, 0, 0 },
        { 0, 1, 0, 0, 0, 0, 0 },
        { 0, 1d/2, 1d/2, 0, 0, 0, 0 },
        { 0, 0, 2d/3, 1d/3, 0, 0, 0 },
        { 0, 0, 0, 1, 0, 0, 0 },
        { 0, 0, 0, 0, 1, 0, 0 },
        { 0, 0, 0, 0, 0, 1, 0 },
        { 0, 0, 0, 0, 0, 0, 1 }
    });
    var size = 4;
    var submatrices =
        // for all possible starting points
        Enumerable.Range(0, height - size + 1).SelectMany(Row =>
            Enumerable.Range(0, width - size + 1).Select(Column => new { Row, Column }))
        // find 4x4 submatrices
        .Select(p => matrix.SubMatrix(p.Row, size, p.Column, size))
        // where all diagonal elements are not zero
        .Where(submatrix => submatrix.Diagonal().All(e => e != 0));
    foreach (var submatrix in submatrices)
        Console.WriteLine(submatrix);
