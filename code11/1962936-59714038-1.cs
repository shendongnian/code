    using (SqlConnection con = new SqlConnection(conString))
                            {
                                SelectCategoryComboBox.Items.Clear();
                                string squery = "SELECT CategoryName FROM CategoryTable";
                                con.Open();
                                SqlDataReader sdr = new SqlCommand(squery, con).ExecuteReader();
                                while (sdr.Read())
                                {
                                    SelectCategoryComboBox.Items.Add(sdr.GetValue(0).ToString());
                                }
    
                            }
