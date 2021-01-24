    public class TableNameEqualityComparer : IEqualityComparer<DataDictionary>
    {
        public bool Equals(DataDictionary x, DataDictionary y)
        {
            if (x == null && y == null)
            {
                return true;
            }
    
            return x != null && y != null && x.TableName == y.TableName;
        }
    
        public int GetHashCode(DataDictionary obj)
        {
            return obj?.TableName?.GetHashCode() ?? 0;
        }
    }
