    static class Program
    {
        static void Main(string[] args)
        {
            // start integer statistics
            var int_ave = Statistics.Int();
            int_ave.Add(3);
            int_ave.Add(5);
            int_ave.Add(7);
            Debug.Assert(int_ave.Count == 3);
            Debug.Assert(int_ave.Average == (3+5+7)/3);
            // start float statistics
            var float_ave = Statistics.Float();
            float_ave.AddRange(2f, 4f, 7f, 9f);
            Debug.Assert(float_ave.Count == 4);
            Debug.Assert(float_ave.Average == (2f+4f+7f+9f)/4);
        }
    }
    /// <summary>
    /// Factory
    /// </summary>
    public static class Statistics
    {
        public static Statistics<byte> Byte() => new Statistics<byte>.ByteStatistics();
        public static Statistics<int> Int() => new Statistics<int>.IntStatistics();
        public static Statistics<float> Float() => new Statistics<float>.FloatStatistics();
        public static Statistics<double> Double() => new Statistics<double>.DoubleStatistics();
        public static Statistics<decimal> Decimal() => new Statistics<decimal>.DecimalStatistics();
    }
    /// <summary>
    /// Base class
    /// </summary>
    public abstract class Statistics<T> where T : struct, IComparable<T>
    {
        public T Average { get; private set; }
        public int Count { get; private set; }
        /// <summary>
        /// When overidden in derived classes the item is considered
        /// and a new average is computed. <see cref="Count"/> is 
        /// also incremented.
        /// </summary>
        /// <param name="item">The numeric value to add.</param>
        public abstract void Add(T item);
        /// <summary>
        /// Adds multiple values
        /// </summary>
        public void AddRange(IEnumerable<T> list)
        {
            foreach (var x in list)
            {
                Add(x);
            }
        }
        /// <summary>
        /// Adds multiple values
        /// </summary>
        public void AddRange(params T[] list)
        {
            AddRange(list.AsEnumerable());
        }
        /// <summary>
        /// Resets the statistics.
        /// </summary>
        public void Reset()
        {
            this.Average = default(T);
            this.Count = 0;
        }
        /// <summary>
        /// Derived class for byte
        /// </summary>
        internal class ByteStatistics : Statistics<byte>
        {
            public override void Add(byte item)
            {
                Average = (byte)((Count*Average + item)/(Count+1) % 256);
                Count += 1;
            }
        }
        /// <summary>
        /// Derived class for int
        /// </summary>
        internal class IntStatistics : Statistics<int>
        {
            public override void Add(int item)
            {
                Average = (Count*Average + item)/(Count+1);
                Count += 1;
            }
        }
        /// <summary>
        /// Derived class for float
        /// </summary>
        internal class FloatStatistics : Statistics<float>
        {
            public override void Add(float item)
            {
                Average = (Count*Average + item)/(Count+1);
                Count += 1;
            }
        }
        /// <summary>
        /// Derived class for double
        /// </summary>
        internal class DoubleStatistics : Statistics<double>
        {
            public override void Add(double item)
            {
                Average = (Count*Average + item)/(Count+1);
                Count += 1;
            }
        }
        /// <summary>
        /// Derived class for decimal
        /// </summary>
        internal class DecimalStatistics : Statistics<decimal>
        {
            public override void Add(decimal item)
            {
                Average = (Count*Average + item)/(Count+1);
                Count += 1;
            }
        }
    }
