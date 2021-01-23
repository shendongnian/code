        public Objective GetNode(IEnumerable<Objective> collection, params int[] indices)
        {
            Objective current = null;
            for (int t = 0; t < indices.Length; t++)
            {
                Objective item = collection.SingleOrDefault(x => x.Parent == current && x.Rank == indices[t] - 1);
                if (item == null)
                    return null;
            }
            return current;
        }
