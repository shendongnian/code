         // Connection String
         private const string ConnStr = 
         "Driver={MySQL ODBC 3.51 Driver};Server=localhost;" + 
         "Database=test;uid=root;pwd=;option=3";
         // DataBinding
         private void BindDataGrid()
         {
             using(OdbcConnection con = new OdbcConnection(ConnStr))
             using(OdbcCommand cmd = 
             new OdbcCommand("SELECT * FROM Sample", con))
             {
                 con.Open();
                 DataGrid1.DataSource = cmd.ExecuteReader(
                    CommandBehavior.CloseConnection | 
                    CommandBehavior.SingleResult);
                 DataGrid1.DataBind();
             }
         }
         // Insert Operation
         private void InsertInfo()
         {
             if(CheckIsAddNameValid())
             {
                 HtmlTable2.Visible = false;
                 using(OdbcConnection con = new OdbcConnection(ConnStr))
                 using(OdbcCommand cmd = new OdbcCommand("INSERT INTO sample" + 
                                "(name, address) VALUES (?,?)", con))
                 {
                     cmd.Parameters.Add("@name", OdbcType.VarChar, 
                                        255).Value = TextBox3.Text.Trim();
                     cmd. Parameters.Add("@address", OdbcType.VarChar, 
                                         255).Value = TextBox4.Text.Trim();
        
                     con.Open();
                     cmd.ExecuteNonQuery();
                     BindDataGrid();
                 }
             }
         }
         // Update Operation
         private void UpdateInfo(int id, string name, string address)
         {
             using(OdbcConnection con = new OdbcConnection(ConnStr))
             using(OdbcCommand cmd = new OdbcCommand("UPDATE sample " + 
                               "SET name = ?, address = ? WHERE ID = ?", con))
             {
                 cmd.Parameters.Add("@name", OdbcType.VarChar, 255).Value = name;
                 cmd.Parameters.Add("@address", 
                       OdbcType.VarChar, 255).Value = address;
                 cmd.Parameters.Add("@ID", OdbcType.Int).Value = id;
    
                 con.Open();
                 cmd.ExecuteNonQuery();
             }
         }
         
         // Update Operation
         private void DeleteInfo(int id)
         {
             using(OdbcConnection con = new OdbcConnection(ConnStr))
             using(OdbcCommand cmd = new OdbcCommand("DELETE " + 
                      "FROM sample WHERE ID = ?", con))
             {
                 cmd.Parameters.Add("@ID", OdbcType.Int).Value = id;
    
                 con.Open();
                 cmd.ExecuteNonQuery();
             }
         }
