    class Program
    {
        static void Main(string[] args)
        {
            DataTable dtInfo = GetTable();
    
    
            var query =
                from row in dtInfo.AsEnumerable() select new
                {
                  name =  row.Field<string>("name"),
                  columnname = 
                  (row.Field<DateTime>("exam1complete")==DateTime.MinValue) 
                  ? 
                  ("exam1date") 
                  :
                  (
                    (row.Field<DateTime>("exam2complete") == DateTime.MinValue) ? ("exam2date") : ("exam3date")
                  ),
                  examdate =
                  (row.Field<DateTime>("exam1complete") == DateTime.MinValue)
                  ?
                  (row.Field<DateTime>("exam1date"))
                  :
                  (
                    (row.Field<DateTime>("exam2complete") == DateTime.MinValue) ? (row.Field<DateTime>("exam2date")) : (row.Field<DateTime>("exam3date"))
                  )
                }
                ;
        }
    
        static DataTable GetTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("name", typeof(string));
            table.Columns.Add("exam1date", typeof(DateTime));
            table.Columns.Add("exam1complete", typeof(DateTime));
            table.Columns.Add("exam2date", typeof(DateTime));
            table.Columns.Add("exam2complete", typeof(DateTime));
            table.Columns.Add("exam3date", typeof(DateTime));
            table.Columns.Add("exam3complete", typeof(DateTime));
    
            table.Rows.Add("joe", "2018-01-30", DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
            table.Rows.Add("james", "2018-02-14", "2018-02-21", "2018-03-02", DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
            table.Rows.Add("javier", "2018-01-01", "2018-01-14", "2018-03-01", "2018-03-12", "2018-04-01", DateTime.MinValue);
            return table;
        }
    }
