    class Program
    {
        static void Main(string[] args)
        {
            List<string> a = new List<string>() { "C", "D", "L" };
            List<string> b = new List<string>() { "C", "L", "C", "D" };
            var pairValuesNotEqual = from vara in a
                    from varb in b
                    where vara != varb
                    select new Pair(vara, varb);
            Set sets = new Set();
            sets.AddRange(pairValuesNotEqual);
            foreach (var item in sets)
            {
                Console.WriteLine(item.First + " - " + item.Second);
            }
            Console.ReadLine();
        }
    }
    public class Set : List<Pair>
    {
        public new void AddRange(IEnumerable<Pair> pairs)
        {
            foreach (var item in pairs)
            {
                this.Add(item);
            }
        }
        public new void Add(Pair item)
        {
            if (!IsExists(item))
                base.Add(item);
        }
        private bool IsExists(Pair item)
        {
            foreach (Pair i in this)
            {
                if (i.First == item.Second && i.Second == item.First)
                    return true;
            }
            return false;
        }
    }
