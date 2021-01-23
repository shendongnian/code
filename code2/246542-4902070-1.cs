    public class ElementClassComparer : IComparer<int>
    {
        public int Compare(int a, int b)
        {
            return x.A > y.A ? 1 : x.A < y.A ? -1 : x.B > y.B ? 1 : x.B < y.B ? -1 : 0
        }
    }
    
    ...
    
    myList.Sort(new ElementClassComparer());
