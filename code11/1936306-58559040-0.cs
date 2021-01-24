    new_Datatable= old_Datatable.AsEnumerable()
                 .Select(c => c.Name, c.Description, c.Amount, c.TotalPrice)
                 .GroupBy(r => r.Field<string>("Name"), r.Field<string>("Description"), r.Field<string>("TotalPrice"))
                 .Select(g =>
                 {
                     var row = old_Datatable.NewRow();
    
                     row["Artikel"] = g.Key;
                     row["Aantal"] = g.Sum(r => r.Field<decimal>("Amount"));
    
                     return row;
                 }).CopyToDataTable();
