    var BaseImageBuilder = MathNet.Numerics.LinearAlgebra.Matrix<double>.Build;
    double[,] BaseImageCoordinates = { { pagePoints.ADash.X, pagePoints.BDash.X, pagePoints.CDash.X }, { pagePoints.ADash.Y, pagePoints.BDash.Y, pagePoints.CDash.Y }, { 1, 1, 1 } };
    var BaseImageMatrix = BaseImageBuilder.DenseOfArray(BaseImageCoordinates);
                    
    double[,] ScanedImageCoordinates = { { pagePoints.A.X, pagePoints.B.X, pagePoints.C.X }, { pagePoints.A.Y, pagePoints.B.Y, pagePoints.C.Y }, { 1, 1, 1 } };
    var ScanedImageMatrix = BaseImageBuilder.DenseOfArray(ScanedImageCoordinates);
    var ScanedInverseMatrix = ScanedImageMatrix.Inverse();
                    
    var H = BaseImageMatrix * ScanedInverseMatrix;
    var rotation = Math.Cos(H[0, 0]) * Math.Cos(H[1, 0]) - Math.Sin(H[1, 0]) * Math.Sin(H[0, 1]);
    transform.Children.Add(new TranslateTransform(H[2, 0], H[2, 1]));                     
    transform.Children.Add(new ScaleTransform(H[0, 0], H[1, 1]));
    transform.Children.Add(new RotateTransform(rotation));
    transform.Children.Add(new TranslateTransform(-H[2, 0], -H[2, 1]));
