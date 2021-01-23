    class RowHelper
    {
        public List<RowSet> RowSets;
        public RowHelper()
        {
            RowSets = new List<RowSet>();
        }
   
        public void CreateRows(SomeClass[] SomeClasses)
        {
            RowSet set = new RowSet();
            foreach(SomeClass rowData in SomeClasses)
            {
                 set.Rows.Add(rowData.ToStringArray());
            }
            RowSets.Add(set);
        }
    } 
