        static Action<Action<int>> OnMyEvent=null;
        static void Main(string[] args)
        {
            OnMyEvent += processResult => processResult(8);
            OnMyEvent += processResult => processResult(16);
            OnMyEvent += processResult => processResult(32);
            var results = new List<int>();
            OnMyEvent(val => results.Add(val));
            foreach (var v in results)
                Console.WriteLine(v);
        }
