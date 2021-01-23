        static void GenerateSuffixedStrings()
        {
            var nxt = false;
            var rnd = new Random();            
            for (var i = 0; i < 100000; i++)
            {
                input.Add(Guid.NewGuid().ToString() + 
                    (rnd.Next(0, 2) == 0 ? suffix : string.Empty));
            }
        }
