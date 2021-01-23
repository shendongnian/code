    class AgeHelper
    {
        private static Dictionary<IEnumerable<int>, string> dic = new Dictionary<IEnumerable<int>, string>
        {
            { Enumerable.Range(0, 10), "0-25" },
            { Enumerable.Range(10, 5), "26-40" },
            { Enumerable.Range(15, 35), "60-100" }
        };
    
        public string this[int age]
        {
            get
            {
                return dic.FirstOrDefault(p => p.Key.Contains(age)).Value ?? "50+";
            }
        }
    }
