    public class MyGenericComparer : IByColumnComparer
    {
      private string columnToCompare;
      private bool descending;
      public string SortColumn
      {
         get { return columnToCompare; }
         set { columnToCompare = value; }
      }
      public bool SortDescending
      {
         get { return descending; }
         set { descending = value; }
      }
      public MyGenericComparer(string column, bool descend)
      {
         columnToCompare = column;
         descending = descend;
      }
      public int Compare(object x, object y)
      {
         MyGenericObject firstObj = (MyGenericObject )x;
         MyGenericObject secondObj = (MyGenericObject )y;
         if (descending) 
         {
            MyGenericObject tmp = secondObj ;
            secondObj = firstObj ;
            firstObj = tmp;
         }
         if (columnToCompare == "StringColumn")
         {
            //Run code to compare strings, return the appropriate int
            //eg, "1" if firstObj was greater, "-1" is secondObj, "0" if equal
         }
         if (columnToCompare == "IntColumn")
         {
            //Run code to compare ints, return the appropriate int
            //eg, "1" if firstObj was greater, "-1" is secondObj, "0" if equal
         }
      }
    }
