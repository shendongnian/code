      DataTable table = new DataTable();
      table.Columns.Add("ID");    //Allows for storage at GetValue(0)
      table.Columns.Add("NAME");  //Allows for storage at GetValue(1)
      
      //GetValue(0) will return 128|256; GetValue(1) will return IP | OP.
      table.Rows.Add(new object[] {"128", "IP"});  
      table.Rows.Add(new object[] {"256", "OP"});
      foreach(DataRow row in table.Rows)
      {
            string name = row.ItemArray.GetValue(1).ToString();
            if(name == "IP")
            {
                 Console.WriteLine("IP was found");
                 //Of course do your edits here.
            }
      }
