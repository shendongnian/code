            string key = "A";
            var query = data.Select(x =>
            {
                var prop = x.GetType().GetProperty(key); //NOTE: if key does not exist this will return null
                return prop.GetValue(x);
            });
            foreach (var value in query)
            {
                Console.WriteLine(value); //will print 1, 2, 3
            }
