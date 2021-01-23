    class abstract GenericNumericUpDown<T>
    {
        public GenericNumericUpDown(T min, T max) { ... }
    }
    
    class NumericUpDownInt : GenericNumericUpDown<int>
    {
        public NumericUpDownInt() : base(int.MinValue, int.MaxValue) { ... }
    }
    
    class NumericUpDownFloat : GenericNumericUpDown<float>
    {
        public NumericUpDownFloat() : base(float.MinValue, float.MaxValue) { ... }
    }
    
    class NumericUpDownDouble : GenericNumericUpDown<double>
    {
        public NumericUpDownDouble() : base(double.MinValue, double.MaxValue) { ... }
    }
