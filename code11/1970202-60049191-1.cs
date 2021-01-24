    public static class DataTableExt {
        public static DataTable UnfoldRow(this DataRow src) {
            var ans = src.Table.Clone();
            var work = src.Table.ColumnNames().Select(cn => src.Field<string>(cn).Split(',')).ToList();
            for (int j1 = 0; j1 < work[0].Length; ++j1)
                ans.Rows.Add(work.Select(w => j1 < w.Length ? w[j1] : "").ToArray());
    
            return ans;
        }
    }
