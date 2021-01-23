    //using System.Dynamic; <-- put this at the top
    Linq<dynamic> list = (from r in table.AsEnumerable()
      let eo = new ExpandoObject()
      let blah = (dt.Columns.Cast<DataColumn>().All(dc => { ((IDictionary<string,object>eo).Add(dc.ColumnName, r[dc]); return true; }))
      select eo).Cast<dynamic>().ToList();
       
    Console.WriteLine(list[0].ID); //your first ID of your DataTable.
    
