    using (SqlConnection scon = new SqlConnection(conString))
                            {
                                string locQuery = "SELECT CategoryName,Categoryid FROM CategoryTable";
                                SqlDataAdapter da = new SqlDataAdapter(locQuery, scon);
                                scon.Open();
                                DataSet ds = new DataSet();
                                da.Fill(ds, "CategoryTable");
                                SelectCategoryComboBox.ValueMember = "Categoryid";
                                SelectCategoryComboBox.DisplayMember = "CategoryName";
                                SelectCategoryComboBox.DataSource = ds.Tables["CategoryTable"];
                            } 
