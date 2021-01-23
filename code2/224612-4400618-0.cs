    // We will be using this in SequenceEquals
    class MyComparer : IEqualityComparer<char>
    {
        public bool Equals(char x, char y)
        {
            return x.Equals(y);
        }
        public int GetHashCode(char obj)
        {
            return obj.GetHashCode();
        }
    }
    // and then:
    var s1 = "ABC0102";
    var s2 = "AC201B0";
    Func<char, double> orderFunction = char.GetNumericValue;
    var comparer = new MyComparer();
    var result = s1.OrderBy(orderFunction).SequenceEqual(s2.OrderBy(orderFunction), comparer);
    Console.WriteLine("result = " + result);
