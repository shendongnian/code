    // calling normal sort:
    ArrayList AscendingList = list.Sort();
    // calling reverse sort:
    ArrayList DescendingList = list.Sort(new ReverseSort());
    
    // implementation:
    public class ReverseSort : IComparer
    {
        public int Compare(object x, object y)
        {
            return Comparer.Default.Compare(y, x);
        }
        
    }
