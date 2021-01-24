         using (var table = new DataTable()) 
		 {
          table.Columns.Add("Item", typeof(string));
          for (int i = 0; i < names.length; i++)
            table.Rows.Add(i.ToString());
          var pList = new SqlParameter("@names", SqlDbType.Structured);
          pList.TypeName = "dbo.StringList";
          pList.Value = table;
          parameters.Add(pList);
       }
