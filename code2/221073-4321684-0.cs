    var combinedrows = from dt1 in DsResults.Tables[0].AsEnumerable() 
                           join dt2 in DsResults.Tables[1].AsEnumerable() on dt1.Field<string>("MethodName") equals dt2.Field<string>("MethodName") 
                           select new { dt1, dt2 }; 
        DataTable finaldt = new DataTable("FinalTable"); 
        finaldt.Columns.Add(new DataColumn("sp",typeof(string))); 
        finaldt.Columns.Add(new DataColumn("Method",typeof(string))); 
        finaldt.Columns.Add(new DataColumn("Class",typeof(string))); 
        finaldt.Columns.Add(new DataColumn("BLLMethod",typeof(string))); 
        foreach(var row in combinedrows )
         {
           DataRow newrow = finaldt.NewRow(); 
           finaldt.Rows.Add(row); 
         }
          dataGridView5.DataSource = finaldt; 
        
