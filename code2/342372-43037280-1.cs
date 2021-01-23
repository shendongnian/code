    public struct UDouble
    {
        /// <summary>
        /// Equivalent to <see cref="double.Epsilon"/>.
        /// </summary>
        public static UDouble Epsilon = double.Epsilon;
        /// <summary>
        /// Represents the smallest possible value of <see cref="UDouble"/> (0).
        /// </summary>
        public static UDouble MinValue = 0d;
        /// <summary>
        /// Represents the largest possible value of <see cref="UDouble"/> (equivalent to <see cref="double.MaxValue"/>).
        /// </summary>
        public static UDouble MaxValue = double.MaxValue;
        /// <summary>
        /// Equivalent to <see cref="double.NaN"/>.
        /// </summary>
        public static UDouble NaN = double.NaN;
        /// <summary>
        /// Equivalent to <see cref="double.PositiveInfinity"/>.
        /// </summary>
        public static UDouble PositiveInfinity = double.PositiveInfinity;
        double value;
        public UDouble(double Value)
        {
            if (double.IsNegativeInfinity(Value))
                throw new NotSupportedException();
            value = Value < 0 ? 0 : Value;
        }
        public static implicit operator double(UDouble d)
        {
            return d.value;
        }
        public static implicit operator UDouble(double d)
        {
            return new UDouble(d);
        }
        public static bool operator <(UDouble a, UDouble b)
        {
            return a.value < b.value;
        }
        public static bool operator >(UDouble a, UDouble b)
        {
            return a.value > b.value;
        }
        public static bool operator ==(UDouble a, UDouble b)
        {
            return a.value == b.value;
        }
        public static bool operator !=(UDouble a, UDouble b)
        {
            return a.value != b.value;
        }
        public static bool operator <=(UDouble a, UDouble b)
        {
            return a.value <= b.value;
        }
        public static bool operator >=(UDouble a, UDouble b)
        {
            return a.value >= b.value;
        }
        public override bool Equals(object a)
        {
            return !(a is UDouble) ? false : this == (UDouble)a;
        }
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
        public override string ToString()
        {
            return value.ToString();
        }
    }
