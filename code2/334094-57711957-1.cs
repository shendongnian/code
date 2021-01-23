    String strConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
                SqlConnection con = new SqlConnection(strConnection);
                con.Open();
                var table = new DataTable();
    
                table.Columns.Add("Item", typeof(string));
                table.Columns.Add("count", typeof(string));
    
                for (int i = 0; i < 10; i++)
                {
                    table.Rows.Add(i.ToString(), (i+i).ToString());
                    
                }
                    SqlCommand cmd = new SqlCommand("exec sp_UseStringList1 @list", con);
                
                       
                        var pList = new SqlParameter("@list", SqlDbType.Structured);
                        pList.TypeName = "dbo.StringList1";
                        pList.Value = table;
    
                        cmd.Parameters.Add(pList);
                        string result = string.Empty;
                        string counts = string.Empty;
                        var dr = cmd.ExecuteReader();
    
                        while (dr.Read())
                        {
                            result += dr["Item"].ToString();
                            counts += dr["counts"].ToString();
                        }
                     
