    using System;
    using System.Collections.Generic;
    public class Program
    {
        public class MyData : IEquatable<MyData>, IComparable<MyData>
        {
            public static implicit operator MyData(string s)    { var data = new MyData(); /* TODO */ return data; }
            public static implicit operator MyData(DateTime dt) { var data = new MyData(); /* TODO */ return data; }
            public static implicit operator MyData(int dt)      { var data = new MyData(); /* TODO */ return data; }
            // implement IComparable<MyData> members...
            // implement IEquatable<MyData> members...
            // override object.Equals()
            // override object.GetHashCode()
            public static bool operator <(MyData a, MyData b) { return Comparer<MyData>.Default.Compare(a,b) == -1; }
            public static bool operator >(MyData a, MyData b) { return Comparer<MyData>.Default.Compare(a,b) == +1; }
            // e.g.: 
            // the desired default representation for comparisons, e.g. string?
            // use 'dynamic' on C# 4.0 and beyond
            private object/*dynamic*/ variant_data;
            public int CompareTo(MyData other)
            {
                // TODO implement your own logic
                return GetHashCode().CompareTo(null != other ? other.GetHashCode() : 0);
            }
            // TODO implement your own equality logic:
            public bool Equals(MyData other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Equals(other.variant_data, variant_data);
            }
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != typeof (MyData)) return false;
                return Equals((MyData) obj);
            }
            public override int GetHashCode() { return (variant_data != null ? variant_data.GetHashCode() : 0); }
            public static bool operator ==(MyData left, MyData right) { return Equals(left, right); }
            public static bool operator !=(MyData left, MyData right) { return !Equals(left, right); }
        }
        public static void Main(string[] args)
        {
            var cmp = Comparer<MyData>.Default;
            string s = "123";
            int i = 234;
            DateTime dt = DateTime.Now;
            if (-1  == cmp.Compare(s, i))  Console.WriteLine("s < i"); 
            if (+1 == cmp.Compare(dt, i)) Console.WriteLine("dt > i");
            // or even:
            if ((MyData) s > i) Console.WriteLine("s > i");
            if ((MyData) dt< i) Console.WriteLine("dt < i");
        }
    }
