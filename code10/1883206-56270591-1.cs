    var points2 = points.ToArray();  // create a copy
    using (Matrix m = new Matrix())
    {
        m.Scale(1.25f, 1.25f, MatrixOrder.Append);
        m.Translate(40, 10, MatrixOrder.Append);
        m.TransformPoints(points2);
    }
