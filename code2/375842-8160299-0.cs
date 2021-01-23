    DataTable table = new DataTable();
    table.Columns.Add("Desc", typeof(string));
    table.Columns.Add("Qty", typeof(decimal));
    table.Columns.Add("Price", typeof(decimal));
    
    table.Rows.Add(new object[] { "Product", 1, 2 });
    table.Rows.Add(new object[] { "Product", 2, 10 });
    table.Rows.Add(new object[] { "Product", 3, null });
    
    var totalQty = table.AsEnumerable().GroupBy(l => l.Field<string>("Desc"))
        .Select(r =>
            new {   Desc = r.Key,
                    TotalQty = r.Sum(w => w.Field<decimal?>("Qty")),
                    TotalPrice = r.Sum(w => w.Field<decimal?>("Price")),
            });
