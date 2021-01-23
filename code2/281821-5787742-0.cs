    List aList = ItemsList.OrderByDescending(x => x.Views, new IntComparer());
    
    public class IntComparer : IComparer<long>
    {
        IComparer<int> Members;
    
        public int Compare(long x, long y)
        {
            return Math.Sign(x - y);
        }
    }
    
    ItemsList = aList;
