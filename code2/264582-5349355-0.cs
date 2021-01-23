            var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            byte [] barr = new byte[128];
            rng.GetBytes(barr);
            foreach (var b in barr)
            {
                Console.WriteLine(b);
            }
