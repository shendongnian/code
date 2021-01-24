    public class MyItemsComparer : IEqualityComparer<MyItems>
    {
        public bool Equals(MyItems c1, MyItems c2)
        {
            if (c2 == null && c1 == null)
                return true;
            else if (c1 == null || c2 == null)
                return false;
            else if (c1.ItemName == c2.ItemName && 
                     c1.ItemDescription == c2.ItemDescription && 
                     c1.DisplaySequence == c2.DisplaySequence)
                return true;
            else
                return false;
        }
    
        public int GetHashCode(MyItems c)
        {
            return (c.ItemName.GetHashCode() ^ c.ItemName.GetHashCode());
        }
    }
