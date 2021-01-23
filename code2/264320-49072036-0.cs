    /// <summary>The Interval class.</summary>
    /// <typeparam name="T">Generic parameter.</typeparam>
    public class Interval<T> : IEquatable<Interval<T>>
        where T : IComparable<T>, IEquatable<T>
    {
        public Interval()
        { }
        public Interval(IntervalValue<T> minimum, IntervalValue<T> maximum)
        {
            this.Minimum = minimum;
            this.Maximum = maximum;
        }
        /// <summary>Minimum value of the interval.</summary>
        public IntervalValue<T>? Minimum { get; set; }
        /// <summary>Maximum value of the interval.</summary>
        public IntervalValue<T>? Maximum { get; set; }
        /// <summary>Presents the Interval in readable format.</summary>
        /// <returns>String representation of the Interval</returns>
        public override string ToString()
        {
            var min = this.Minimum;
            var max = this.Maximum;
            var sb = new StringBuilder();
            if (min.HasValue)
                sb.AppendFormat(min.Value.ToString(IntervalNotationPosition.Left));
            else
                sb.Append("(-∞");
            sb.Append(',');
            if (max.HasValue)
                sb.AppendFormat(max.Value.ToString(IntervalNotationPosition.Right));
            else
                sb.Append("∞)");
            var result = sb.ToString();
            return result;
        }
        /// <summary>Determines if the interval is valid.</summary>
        /// <returns>True if interval is valid, else false</returns>
        public bool IsValid()
        {
            var min = this.Minimum;
            var max = this.Maximum;
            if (min.HasValue && max.HasValue)
                return min.Value.Value.CompareTo(max.Value.Value) <= 0;
            return true;
        }
        /// <summary>Determines if the provided value is inside the interval.</summary>
        /// <param name="x">The value to test</param>
        /// <returns>True if the value is inside Interval, else false</returns>
        public bool ContainsValue(T x)
        {
            if (x == null)
                throw new ArgumentNullException(nameof(x));
            var min = this.Minimum;
            var max = this.Maximum;
            var isValid = this.IsValid();
            if (!isValid)
                throw new InvalidOperationException("Interval is not valid.");
            bool result = true; // (-∞,∞)
            if (min.HasValue)
            {
                if (min.Value.Type == IntervalValueType.Exclusive)
                    result &= min.Value.Value.CompareTo(x) < 0;
                else if (min.Value.Type == IntervalValueType.Inclusive)
                    result &= min.Value.Value.CompareTo(x) <= 0;
                else
                    throw new NotSupportedException();
            }
            if (max.HasValue)
            {
                if (max.Value.Type == IntervalValueType.Exclusive)
                    result &= max.Value.Value.CompareTo(x) > 0;
                else if (max.Value.Type == IntervalValueType.Inclusive)
                    result &= max.Value.Value.CompareTo(x) >= 0;
                else
                    throw new NotSupportedException();
            }
            return result;
        }
        public bool Equals(Interval<T> other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return this.Minimum?.Equals(other.Minimum) == true
                && this.Maximum?.Equals(other.Maximum) == true;
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Interval<T>);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash = hash * 16777619 ^ this.Minimum?.GetHashCode() ?? 0;
                hash = hash * 16777619 ^ this.Maximum?.GetHashCode() ?? 0;
                return hash;
            }
        }
    }
    public struct IntervalValue<T> : IEquatable<IntervalValue<T>>
        where T : IComparable<T>, IEquatable<T> //, IFormattable
    {
        private readonly T value;
        private readonly IntervalValueType type;
        public IntervalValue(T value, IntervalValueType type)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            this.value = value;
            this.type = type;
        }
        public T Value
        {
            get { return this.value; }
        }
        public IntervalValueType Type
        {
            get { return this.type; }
        }
        public bool Equals(IntervalValue<T> other)
        {
            return this.value.Equals(other.value)
                && this.type == other.type;
        }
        public override bool Equals(object obj)
        {
            return obj is IntervalValue<T> && this.Equals((IntervalValue<T>)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;
                hash = hash * 16777619 ^ this.value.GetHashCode();
                hash = hash * 16777619 ^ this.type.GetHashCode();
                return hash;
            }
        }
        internal string ToString(IntervalNotationPosition position)
        {
            var notation = this.Type.ToString(position);
            switch (position)
            {
                case IntervalNotationPosition.Left:
                    return string.Format("{0}{1}", notation, this.Value);
                case IntervalNotationPosition.Right:
                    return string.Format("{0}{1}", this.Value, notation);
                default:
                    throw new NotSupportedException();
            }
        }
    }
    internal static class IntervalValueTypeExtensions
    {
        public static string ToString(this IntervalValueType type, IntervalNotationPosition position)
        {
            switch (position)
            {
                case IntervalNotationPosition.Left:
                    switch (type)
                    {
                        case IntervalValueType.Inclusive: return "[";
                        case IntervalValueType.Exclusive: return "(";
                        default:
                            throw new NotSupportedException();
                    }
                case IntervalNotationPosition.Right:
                    switch (type)
                    {
                        case IntervalValueType.Inclusive: return "]";
                        case IntervalValueType.Exclusive: return ")";
                        default:
                            throw new NotSupportedException();
                    }
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    }
    public enum IntervalValueType
    {
        Inclusive,
        Exclusive
    }
    public enum IntervalNotationPosition
    {
        Left,
        Right
    }
