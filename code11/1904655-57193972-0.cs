c#
            DataTable Dt2 = new DataTable();
            Dt2 = dt.AsEnumerable()
                .GroupBy(r => r.Field<string>("Vegetables"))
                .Select(g =>
                {
                    var row = dt.NewRow();
                    row["Vegetables"] = g.Key;
                    row["Pricing"] = g.Average(r => Int32.Parse(r.Field<string>("Pricing")));
                    return row;
                })
                .OrderBy(row => row["Pricing"])
                .Reverse()
                .CopyToDataTable();
The second is just using `.OrderByDescending<T>()`:
c#
            DataTable Dt2 = new DataTable();
            Dt2 = dt.AsEnumerable()
                .GroupBy(r => r.Field<string>("Vegetables"))
                .Select(g =>
                {
                    var row = dt.NewRow();
                    row["Vegetables"] = g.Key;
                    row["Pricing"] = g.Average(r => Int32.Parse(r.Field<string>("Pricing")));
                    return row;
                })
                .OrderByDescending(row => row["Pricing"])
                .CopyToDataTable();
If you're looking for a non-Linq solution could also apply a sorted `DataView` on the `DataTable` to achieve a similar result.
