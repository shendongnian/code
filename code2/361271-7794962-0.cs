    class Program
    {
        static void Main()
        {
            var dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Rows.Add(1, "x");
            dt.Rows.Add(2, "y");
    
            List<dynamic> dynamicDt = dt.ToDynamic();
            Console.WriteLine(dynamicDt.First().ID);
            Console.WriteLine(dynamicDt.First().Name);
        }
    }
    
    public static class DataTableExtensions
    {
        public static List<dynamic> ToDynamic(this DataTable dt)
        {
            var dynamicDt = new List<dynamic>();
            foreach (DataRow row in dt.Rows)
            {
                dynamic dyn = new ExpandoObject();
                foreach (DataColumn column in dt.Columns)
                {
                    var dic = (IDictionary<string, object>)dyn;
                    dic[column.ColumnName] = row[column];
                    dynamicDt.Add(dyn);
                }
            }
            return dynamicDt;
        }
    }
