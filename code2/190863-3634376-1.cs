        static void Main()
        {
            var weighting = new Dictionary<char, int>();
            weighting['A'] = 10; //10%
            weighting['B'] = 20; //20%
            weighting['C'] = 30; //30%
            weighting['D'] = 40; //40% (total = 100%)
            var test = CreateOrder(weighting);
        }
        static IEnumerable<char> CreateOrder(Dictionary<char, int> weighting)
        {
            var list = new List<KeyValuePair<int, char>>();
            var random = new Random();
            foreach (var i in weighting)
            {
                for (int j = 0; j < i.Value; j++)
                {
                    list.Add(new KeyValuePair<int, char>(random.Next(), i.Key));
                }
            }
            return list.OrderBy(u=>u.Key).Select(u => u.Value);
        }
