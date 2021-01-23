         DataSet Contents = new DataSet();
         using (OleDbDataAdapter adapter = new OleDbDataAdapter("select FirstName,LastName,Email,Mobile from [" + mySheet + "]", connection))
         {
             adapter.Fill(Contents,"MyTable");
         }
         foreach (DataRow content in Contents.Tables["MyTable"].Rows)
         {
             if (content[0].ToString() == "" && content[0].ToString() == "" && content[0].ToString() == "" && content[0].ToString() == "")
             {
                 Console.WriteLine("Empty Row");
             }
             else
             {
                 Console.WriteLine(content[0] + " | " + content[1] + " | " + content[2] + " | " + content[3]);
             }
         }
