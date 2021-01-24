    struct Position
    {
        private int[] _values;
        Position(int x, int y, int z)
        {
            _values = new []{x, y, z};
        }
        public int X => _values[0]; 
        public int Y => _values[1]; 
        public int Z => _values[2];
        public int this[int dimension] => _values[dimension];
    }
