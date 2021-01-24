    public static class IEnumerableExt {
        public static DataTable ToDataTable(this IEnumerable<DataRow> src) {
            var ans = src.First().Table.Clone();
            foreach (var r in src)
                ans.ImportRow(r);
            return ans;
        }    
    }
    
