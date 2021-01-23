        public static List<string> GetChunks(string value, int chunkSize)
        {
            List<string> triplets = new List<string>();
            while (value.Length > chunkSize)
            {
                triplets.Add(value.Substring(0, chunkSize));
                value = value.Substring(chunkSize);
            }
            if (value != "")
                triplets.Add(value);
            return triplets;
        }
