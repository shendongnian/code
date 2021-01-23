    class Program
    {
        static void Main(string[] args)
        {
            var i = 1;
            var j = 34;
            var k = true;
            Match(i, j, k).
                With(1, 2, 3).Do(() => Console.WriteLine("1, 2, 3")).
                With(1, 34, false).Do(() => Console.WriteLine("1, 34, false")).
                With(1, 34, true).Do(() => Console.WriteLine("1, 34, true"));
        }
        static Matcher Match(params object[] values)
        {
            return new Matcher(values);
        }
    }
    public class Matcher
    {
        private readonly object[] values;
        public object[] Values
        {
            get { return values; }
        }
        public Matcher(object[] values)
        {
            this.values = values;
        }
        public Match With(params object[] matchedValues)
        {
            return new Match(this, matchedValues);
        }
    }
    public class Match
    {
        private readonly Matcher matcher;
        private readonly object[] matchedValues;
        public Match(Matcher matcher, object[] matchedValues)
        {
            this.matcher = matcher;
            this.matchedValues = matchedValues;
        }
        public Matcher Do(Action a)
        {
            if(matcher.Values.SequenceEqual(matchedValues))
                a();
            return matcher;
        }
    }
