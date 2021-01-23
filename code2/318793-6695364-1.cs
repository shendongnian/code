    // calling normal sort:
    ArrayList ascendingList = list.Sort();
    // calling reverse sort:
    ArrayList descendingList = list.Sort(new ReverseSort());
    
    // implementation:
    public class ReverseSort : IComparer
    {
        public int Compare(object x, object y)
        {
            // reverse the arguments
            return Comparer.Default.Compare(y, x);
        }
        
    }
