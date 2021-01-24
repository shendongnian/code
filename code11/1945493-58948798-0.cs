    public static string GenerateUniqueRandomNumbers()
        {
            Random generator = new Random();
            String r = generator.Next(0, 1000000).ToString("D6");
            r += generator.Next(0, 10000000).ToString("D7");
            if (r.Distinct().Count() == 1)
            {
                r = GenerateUniqueRandomNumbers();
            }
            return r;
        }
