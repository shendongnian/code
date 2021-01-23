    class Program
    {
        static void Main(string[] args)
        {
            var i = 1;
            var j = 34;
            var k = true;
            Match(i, j, k).
                With(1, 2, false).Do(() => Console.WriteLine("1, 2, 3")).
                With(1, 34, false).Do(() => Console.WriteLine("1, 34, false")).
                With(x => i > 0, x => x < 100, x => x == true).Do(() => Console.WriteLine("1, 34, true"));
        }
        static Matcher<T1, T2, T3> Match<T1, T2, T3>(T1 t1, T2 t2, T3 t3)
        {
            return new Matcher<T1, T2, T3>(t1, t2, t3);
        }
    }
    public class Matcher<T1, T2, T3>
    {
        private readonly object[] values;
        public object[] Values
        {
            get { return values; }
        }
        public Matcher(T1 t1, T2 t2, T3 t3)
        {
            values = new object[] { t1, t2, t3 };
        }
        public Match<T1, T2, T3> With(T1 t1, T2 t2, T3 t3)
        {
            return new Match<T1, T2, T3>(this, new object[] { t1, t2, t3 });
        }
        public Match<T1, T2, T3> With(Func<T1, bool> t1, Func<T2, bool> t2, Func<T3, bool> t3)
        {
            return new Match<T1, T2, T3>(this, t1, t2, t3);
        }
    }
    public class Match<T1, T2, T3>
    {
        private readonly Matcher<T1, T2, T3> matcher;
        private readonly object[] matchedValues;
        private readonly Func<object[], bool> matcherF; 
        public Match(Matcher<T1, T2, T3> matcher, object[] matchedValues)
        {
            this.matcher = matcher;
            this.matchedValues = matchedValues;
        }
        public Match(Matcher<T1, T2, T3> matcher, Func<T1, bool> t1, Func<T2, bool> t2, Func<T3, bool> t3)
        {
            this.matcher = matcher;
            matcherF = objects => t1((T1)objects[0]) && t2((T2)objects[1]) && t3((T3)objects[2]);
        }
        public Matcher<T1, T2, T3> Do(Action a)
        {
            if(matcherF != null && matcherF(matcher.Values) || matcher.Values.SequenceEqual(matchedValues))
                a();
            return matcher;
        }
    }
