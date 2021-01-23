    class A
    {
        static public IEnumerable<string> FetchItems(int max, Predicate<string> filter)
        {
            var l = new List<string>() {"test", "fest", "pest", "häst"};
            return l.FindAll(filter).Take(max);
        }
    }
