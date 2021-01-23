    public class Example
    {
        public class MyComparer : IComparer  {
           int IComparer.Compare( Object x, Object y )  
           {
              // return -1, 0 or 1 by comparing x & y
           } 
        }  
    
        public static void Main()
        {
            SortedList allRules = new SortedList(new MyComparer ())
            allRules.Add(...); // Sorted each time
            allRules.Add(...); // Sorted each time
            allRules.Add(...); // Sorted each time
            allRules.Add(...); // Sorted each time
        }
    }
