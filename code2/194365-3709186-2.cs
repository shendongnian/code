            var list = new List<int?>()
            {
                1,
                null
            };
            foreach (int? i in list)
            {
                if (!i.HasValue)
                {
                    continue;
                }
                
                Console.WriteLine(i.GetType());
            }
            foreach (int i in list)
            {
                Console.WriteLine(i.GetType());
            }
