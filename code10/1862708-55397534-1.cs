    DataTable dt = new DataTable();
    dt.Columns.Add("Agent", typeof(string));
    dt.Columns.Add("Amount", typeof(decimal));
    dt.Columns.Add("Date", typeof(string));
    
    
    DataTable result = dtTemp.AsEnumerable()
         .Select(x => new
         {
             Agent = x.Field<string>("Agent"),
             Amount = x.Field<decimal>("Amount"),
             Date = x.Field<DateTime>("Date").ToString("MM-yyyy")
         })
         .GroupBy(x => new { x.Agent, x.Date })
         .Select(g =>
         {
             var r = dt.NewRow();
         
             r["Agent"] = g.Key.Agent;
             r["Amount"] = g.Sum(c => c.Amount);
             r["Date"] = g.FirstOrDefault().Date;
         
             return r;
         })
         .CopyToDataTable();
    
    
