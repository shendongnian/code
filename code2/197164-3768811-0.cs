    public int this[int x, int y]
    {
        get { return (x * ColSize + y); }
    }
---
    class TheMatrix<T>
    {
        private int _rows, _cols;
        private T[] _data;
        public TheMatrix(int rows, int cols)
        {
            _rows = rows;
            _cols = cols;
            _data = new T[_rows * _cols];
        }
        T this[int r, int c]
        {
            get { return _data[r * _cols + c]; }
            set { _data[r * _cols + c] = value; }
        }
    }
