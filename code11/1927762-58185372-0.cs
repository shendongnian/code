    using (SqlCommand cmd = new SqlCommand("select * from test1", con))
                    {
                        DataTable dt = new DataTable();
                        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                        adpt.Fill(dt);
                        Dictionary<int,> lst = new Dictionary<int,>();
                        foreach (DataRow row in dt.Rows)
                        {
                            //Add values to Dictionary
                            string val = row[1].ToString() + " , " + row[2].ToString() + " , " + row[3].ToString();
                            lst.Add(Convert.ToInt32(row[0]), val);
                        }
                        DropDownList1.DataSource = lst;
                        DropDownList1.DataTextField = "Value";
                        DropDownList1.DataValueField = "Key";
                        DropDownList1.DataBind();
                    }
