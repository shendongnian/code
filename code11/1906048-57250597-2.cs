    class Program
    {
        static void Main(string[] args)
        {
            var dt1 = CreateFirtsTable();
            var dt2 = CreateSecondTable();
            var dt = Merge(dt1, dt2);
        }
        static DataTable CreateFirtsTable()
        {
            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("String", typeof(string)),
                new DataColumn("Int", typeof(int))
            });
            dt.Rows.Add("one", 1);
            dt.Rows.Add("two", 2);
            dt.Rows.Add("three", 3);
            return dt;
        }
        static DataTable CreateSecondTable()
        {
            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Int", typeof(int)),
                new DataColumn("String", typeof(string))
            });
            dt.Rows.Add(4, "four");
            dt.Rows.Add(5, "five");
            dt.Rows.Add(6, "six");
            return dt;
        }
        static DataTable Merge(DataTable dt1, DataTable dt2)
        {
            if (dt1.Columns.Count != dt2.Columns.Count)
                throw new ArgumentException("Columns count does not match");
            var dt = new DataTable();
            foreach (var col in dt1.Columns)
                dt.Columns.Add();
            foreach (var row in dt1.Rows.Cast<DataRow>())
                dt.Rows.Add(row.ItemArray);
            foreach (var row in dt2.Rows.Cast<DataRow>())
                dt.Rows.Add(row.ItemArray);
            return dt;
        }
    }
