    static class EmptyDenseMatrix
    {
        public static DenseMatrix Create()
        {
            var storage = DenseColumnMajorMatrixStorage<double>.OfArray(new double[1, 1]);
            var type = typeof(DenseColumnMajorMatrixStorage<double>);
            type.GetField("RowCount").SetValue(storage, 0);
            type.GetField("ColumnCount").SetValue(storage, 0);
            type.GetField("Data").SetValue(storage, new double[0]);
            return new DenseMatrix(storage);
        }
    }
