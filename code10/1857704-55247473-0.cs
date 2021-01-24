    public static class DataTableExt {
        public static DataTable PivotByOverWithTotal(this DataTable dt, string ByRowFieldName, string OverColFieldName) {
            var res = new DataTable();
            if (dt.Rows.Count > 0) {
                var dtg = dt.AsEnumerable().GroupBy(r => r[ByRowFieldName], r => r[OverColFieldName].ToString());
    
                res.Columns.Add(ByRowFieldName, dt.Columns[ByRowFieldName].DataType);
                var colNames = dtg.SelectMany(rg => rg).Distinct().OrderBy(n => n);
                foreach (var n in colNames)
                    res.Columns.Add(n, typeof(int));
                res.Columns.Add("Total", typeof(int));
    
                foreach (var rg in dtg) {
                    var newr = res.NewRow();
                    newr[ByRowFieldName] = rg.Key;
                    int total = 0;
                    foreach (var rv in colNames) {
                        var val = rg.Contains(rv) ? 1 : 0;
                        newr[rv] = val;
                        total += val;
                    }
                    newr["Total"] = total;
                    res.Rows.Add(newr);
                }
            }
            return res;
        }
    }
