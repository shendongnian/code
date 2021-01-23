    public static string GenerateNewCode(int length)
        {
            string newCode = String.Empty;
            int seed = unchecked(DateTime.Now.Ticks.GetHashCode());
            Random random = new Random(seed);
    
            // keep going until we find a unique code       
            do
            {
                newCode = random.Next(Math.Pow(10,length-1), Math.Pow(10,length)-1).ToString("0000")
            }
            while (!ConsumerCode.isUnique(newCode));
    
            // return
            return newCode;
        }
