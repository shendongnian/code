    public static class StringsEx
    {
        public static IEnumerable<String> Like(this IEnumerable<String> input, String pattern)
        {
            var dt = new DataTable();
            dt.Columns.Add("Search");
            foreach (String str in input)
            {
                dt.Rows.Add(str);
            }
            dt.DefaultView.RowFilter = String.Format("Search LIKE '{0}'", pattern);
            return dt.DefaultView.ToTable()
                .AsEnumerable()
                .Select(r => r.Field<String>("Search"));
        }
    }
