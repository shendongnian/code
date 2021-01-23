        public static List<string> GetTriplets(string value)
        {
            List<string> triplets = new List<string>();
            while (value.Length > 3)
            {
                triplets.Add(value.Substring(0, 3));
                value = value.Substring(3);
            }
            if (value != "")
                triplets.Add(value);
            return triplets;
        }
