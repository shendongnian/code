    public class Matrix<T>
    {
        private readonly T[][] _matrix;
        public Matrix(int rows, int cols)
        {
            _matrix = new T[rows][];
            for (int r = 0; r < rows; r++)
                _matrix[r] = new T[cols];
        }
        public T this[int r, int c]
        {
            get
            { return _matrix[r][c]; }
        }
    }
