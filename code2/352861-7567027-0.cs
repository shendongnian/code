     List<string> lista = new List<string>() { "aaaa", "aaabb", "aaacccc", "eee" };
            var param = Expression.Parameter(typeof(string), "s");
            var pattern = Expression.Constant("\\Aa");
            var test = Expression.Call(typeof(Regex), "IsMatch", null, param, pattern);
            var lambda = Expression.Lambda<Func<string, bool>>(test, param);
            IEnumerable<string> query = lista.Where(lambda.Compile());
            foreach (string s in query) 
            {
                Console.WriteLine(s);
            }
