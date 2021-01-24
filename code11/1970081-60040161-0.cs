    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            var a1 = GetFirstType(42);
            var b1 = GetFirstType(43);
            var c1 = GetFirstType(42);
            if (object.ReferenceEquals(a1, b1))
                Console.WriteLine("a1 == b1");
            else
                Console.WriteLine("a1 != b1");
            if (object.ReferenceEquals(b1, c1))
                Console.WriteLine("b1 == c1");
            else
                Console.WriteLine("b1 != c1");
            if (object.ReferenceEquals(a1, c1))
                Console.WriteLine("a1 == c1");
            else
                Console.WriteLine("a1 != c1");
            Console.WriteLine();
            var a2 = GetSecondType("42");
            var b2 = GetSecondType("43");
            var c2 = GetSecondType("42");
            if (object.ReferenceEquals(a2, b2))
                Console.WriteLine("a2 == b2");
            else
                Console.WriteLine("a2 != b2");
            if (object.ReferenceEquals(b2, c2))
                Console.WriteLine("b2 == c2");
            else
                Console.WriteLine("b2 != c2");
            if (object.ReferenceEquals(a2, c2))
                Console.WriteLine("a2 == c2");
            else
                Console.WriteLine("a2 != c2");
        }
        public static FirstType GetFirstType(int value)
        {
            var item = new FirstType(value);
            if (_lookup.TryGetValue(item, out var found))
                return (FirstType) found;
            _lookup.Add(item);
            return item;
        }
        public static SecondType GetSecondType(string value)
        {
            var item = new SecondType(value);
            if (_lookup.TryGetValue(item, out var found))
                return (SecondType)found;
            _lookup.Add(item);
            return item;
        }
        static HashSet<object> _lookup = new HashSet<object>();
    }
    public sealed class FirstType: IEquatable<FirstType>
    {
        public FirstType(int value)
        {
            IntValue = value;
        }
        public int IntValue { get; }
        public bool Equals(FirstType? other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return IntValue == other.IntValue;
        }
        public override bool Equals(object? obj)
        {
            return ReferenceEquals(this, obj) || obj is FirstType other && Equals(other);
        }
        public override int GetHashCode()
        {
            return IntValue;
        }
        public static bool operator ==(FirstType? left, FirstType? right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(FirstType? left, FirstType? right)
        {
            return !Equals(left, right);
        }
    }
    sealed class SecondType: IEquatable<SecondType>
    {
        public SecondType(string value)
        {
            StringValue = value;
        }
        public string StringValue { get; }
        public bool Equals(SecondType? other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return StringValue == other.StringValue;
        }
        public override bool Equals(object? obj)
        {
            return ReferenceEquals(this, obj) || obj is SecondType other && Equals(other);
        }
        public override int GetHashCode()
        {
            return StringValue.GetHashCode();
        }
        public static bool operator ==(SecondType? left, SecondType? right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(SecondType? left, SecondType? right)
        {
            return !Equals(left, right);
        }
    }
