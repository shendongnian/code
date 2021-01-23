     String cs = @"Provider=Microsoft.ACE.OLEDB.12.0;Data    
     Source=databasepath\databasename.mdb"; 
     OleDbConnection con = new OleDbConnection(cs);
     con.Open();
     OleDbCommand com = new OleDbCommand("select Max(id) as ID from tablename",
     con);
     com.CommandType = CommandType.Text;
     OleDbDataReader r = com.ExecuteReader();
     r.Read();
     if (r["ID"].ToString() != "")
               {
                   temp = int.Parse(r["ID"].ToString()) + 1;
               }
     else
               {
                    temp = 1;
               }
     textBox1.Text = temp.ToString();
     r.Close();
     con.Close();
