    using System;
    public class MyNullable<T> where T : struct
    {
        internal T value;
        public MyNullable(T value)
        {
            this.value = value;
            this.HasValue = true;
        }
        public bool HasValue { get; }
        public T Value
        {
            get
            {
                if (!this.HasValue) throw new Exception("Cannot grab value when has no value");
                return this.value;
            }
        }
        public static explicit operator T(MyNullable<T> value)
        {
            return value.Value;
        }
        public static implicit operator MyNullable<T>(T value)
        {
            return new MyNullable<T>(value);
        }
        public static bool operator ==(MyNullable<T> n1, MyNullable<T> n2)
        {
            if (!n1.HasValue) return !n2.HasValue;
            if (!n2.HasValue) return false;
            return Equals(n1.value, n2.value);
        }
        public static bool operator !=(MyNullable<T> n1, MyNullable<T> n2)
        {
            return !(n1 == n2);
        }
        public override bool Equals(object other)
        {
            if (!this.HasValue) return other == null;
            if (other == null) return false;
            return this.value.Equals(other);
        }
        public override int GetHashCode()
        {
            return this.HasValue ? this.value.GetHashCode() : 0;
        }
        public T GetValueOrDefault()
        {
            return this.value;
        }
        public T GetValueOrDefault(T defaultValue)
        {
            return this.HasValue ? this.value : defaultValue;
        }
        public override string ToString()
        {
            return this.HasValue ? this.value.ToString() : string.Empty;
        }
    }
}
