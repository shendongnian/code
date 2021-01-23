    class RollingMean
    {
        int _pos;
        int _count;
        double[] _buffer;
        public RollingMean(int size)
        {
            _buffer = new double[size];
            _pos = 0;
            _count = 0;
        }
        public RollingMean(int size, double initialValue) 
            : this(size)
        {
            //  Believe it or not there doesn't seem to be a better(performance) way...
            for (int i = 0; i < size; i++)
            {
                _buffer[i] = initialValue;
            }
            _count = size;
        }
        public double Push(double value)
        {
            _buffer[_pos] = value;
            _pos = (++_pos > _buffer.Length - 1) ? 0 : _pos;
            _count = Math.Min(++_count, _buffer.Length);
            return Mean;
        }
        public double Mean
        {
            get
            {
                return _buffer.Sum() / _count;
            }
        }
    }
