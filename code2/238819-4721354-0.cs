        IEnumerable<int>  GenrateIDs(int max)
        {
            Random rand = new Random();
            HashSet<int> IDs = new HashSet<int>();
            while (IDs.Count < max)
            {
                IDs.Add(rand.Next(max));
            }
            return IDs.AsEnumerable();
        }
