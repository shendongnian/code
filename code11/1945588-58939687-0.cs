      protected void ImportCSV(object sender, EventArgs e)
            {
                importbtn();
    
            }
            public class Item
            {
                public Item(string line)
                {
                    var split = line.Split(',');
                    string FIELD1 = split[0];
                    string FIELD2 = split[1];
                    string FIELD3 = split[2];
    
    
                    string mainconn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    
                    using (SqlConnection con = new SqlConnection(mainconn))
                    {
                        using (SqlCommand cmd = new SqlCommand("storedProcedureName", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
    
    
                            cmd.Parameters.AddWithValue("@FIELD1", SqlDbType.VarChar).Value = FIELD1;
                            cmd.Parameters.AddWithValue("@FIELD2", SqlDbType.VarChar).Value = FIELD2;
                            cmd.Parameters.AddWithValue("@FIELD3", SqlDbType.VarChar).Value = FIELD3;
    
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
    
    
                    }
    
                }
            }
            private void importbtn()
            {
                try
                {
    
                    string csvPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(csvPath);
    
    
                    var listOfObjects = File.ReadLines(csvPath).Select(line => new Item(line)).ToList();
    
    
                    DataTable dt = new DataTable();
    
                    dt.Columns.AddRange(new DataColumn[3] { new DataColumn("FIELD1", typeof(string)),
                    new DataColumn("FIELD2", typeof(string)),
                    new DataColumn("FIELD3",typeof(string)) });
    
    
                    string csvData = File.ReadAllText(csvPath);
    
    
                    foreach (string row in csvData.Split('\n'))
                    {
    
                        if (!string.IsNullOrEmpty(row))
                        {
    
    
                            dt.Rows.Add();
    
                            int i = 0;
    
                            //Execute a loop over the columns.
                            foreach (string cell in row.Split(','))
                            {
    
    
                                dt.Rows[dt.Rows.Count - 1][i] = cell;
    
                                i++;
    
                            }
    
                        }
                    }
    
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
    
    
                    Label1.Text = "File Attached Successfully";
    
    
    
                }
                catch (Exception ex)
                {
                    Message.Text = "Please Attach any File" /*+ ex.Message*/;
    
                }
            }
