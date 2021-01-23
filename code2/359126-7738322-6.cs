    public class Matrix<T>
    {
        private readonly List<List<T>> _matrix;
        public Matrix()
        {
            _matrix = new List<List<T>>();
        }
        public T this[int r, int c]
        {
            get
            {
                ResizeIfNeeded(r, c);
                return _matrix[r][c]; 
            }
            set
            {
                ResizeIfNeeded(r, c);
                _matrix[r][c] = value;
            }
        }
        private void ResizeIfNeeded(int row, int col)
        {
            while (_matrix.Count <= r)
                _matrix.Add(new List<T>());
            var row = _matrix[r];
            while (row.Count <= c)
                row.Add(default(T));
        }
    }
