    public class EntityColumnCompare : IEqualityComparer<Entity>
    {
        public bool Equals(Entity a, Entity b)
        {
            if (a.Columns.Count != b.Columns.Count)
                return false; // Different number of items
            foreach(var kvp in a.Columns)
            {
                object bValue;
                if (!b.Columns.TryGetValue(kvp.Key, out bValue))
                    return false; // key missing in b
                if (!Equals(kvp.Value, bValue))
                    return false; // value is different
            }
            return true;
        }
    
        public int GetHashCode(Entity obj)
        {
            return obj.Columns.GetHashCode(); 
        }
    }
