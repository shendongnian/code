    class Program
    {
        static void Main(string[] args)
        {
            var x = new List<Tuple<string,string>> { { "1", "2" }, { "1", "2" } };
        }
    }
    public static class Extensions
    {
        public static void Add<T1,T2>(this List<Tuple<T1,T2>> self, T1 value1, T2 value2)
        {
            self.Add(Tuple.Create( value1, value2 ));
        }
    }
