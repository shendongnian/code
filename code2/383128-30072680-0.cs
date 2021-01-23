    public struct Year : IEquatable<Year>, IEquatable<DateTime>, IEquatable<int>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     When <see cref="year"/> is not within the range from <value>1</value> to <value>9999</value>.
        /// </exception>
        public Year(int year)
        {
            // same limits as DateTime 
            // be careful when changing this values, because it might break
            // conversion from and to DateTime 
            var min = 1;
            var max = 9999;
            if (year < min || year > max)
            {
                var message = string.Format("Year must be between {0} and {1}.", min, max);
                throw new ArgumentOutOfRangeException("year", year, message);
            }
            _value = year;
        }
        private readonly int _value;
        public bool Equals(Year other)
        {
            return _value == other._value;
        }
        public bool Equals(DateTime other)
        {
            return _value == other.Year;
        }
        public bool Equals(int other)
        {
            return _value == other;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (obj is Year) return Equals((Year) obj);
            if (obj is int) return Equals((int)obj);
            if (obj is DateTime) return Equals((DateTime) obj);
            return false;
        }
        public static Year MinValue 
        {
            get
            {
                return new Year(DateTime.MinValue.Year);
            }
        }
        public static Year MaxValue
        {
            get
            {
                return new Year(DateTime.MaxValue.Year);
            }
        }
        public override int GetHashCode()
        {
            return _value;
        }
        public static bool operator ==(Year left, Year right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Year left, Year right)
        {
            return !left.Equals(right);
        }
        public override string ToString()
        {
            return _value.ToString();
        }
        public string ToString(IFormatProvider formatProvider)
        {
            return _value.ToString(formatProvider);
        }
        public string ToString(string format)
        {
            return _value.ToString(format);
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return _value.ToString(format, formatProvider);
        }
        public DateTime ToDateTime()
        {
            return new DateTime(_value, 1, 1);
        }
        public int ToInt()
        {
            return _value;
        }
        public static implicit operator DateTime(Year year)
        {
            return new DateTime(year._value, 1, 1);
        }
        public static explicit operator Year(DateTime dateTime)
        {
            return new Year(dateTime.Year);
        }
        public static explicit operator int(Year year)
        {
            return year._value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     When <see cref="year"/> is not within the range from <value>1</value> to <value>9999</value>.
        /// </exception>
        public static explicit operator Year(int year)
        {
            return new Year(year);
        }
    }
