    class Cleint
    {
        private static Random random = new Random();
        public string GenerateAddress()
        {
            var parts = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                int newPart = random.Next(0, 255);
                parts.Add(newPart.ToString());
            }
            string address = string.Join(".", parts);
            return address;
        }
    }
