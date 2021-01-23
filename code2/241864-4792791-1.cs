    string strConnectionString = ConfigurationManager.ConnectionStrings["SqlServerCstr"].ConnectionString;
    
            using (SqlConnection myConnection = new SqlConnection(strConnectionString))
            {
                string query = "select B.HESAP_NO FROM  YAZ.MARDATA.S_TEKLIF B WHERE B.MUS_K_ISIM = @selectedItem";
                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {
                    cmd.Parameters.AddWithValue("@selectedItem", DropDownList1.SelectedValue.ToString());
                    myConnection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            Label1.Text = dr["B.HESAP_NO"].ToString();
                        }
                        dr.Close();
                    }
                }
                myConnection.Close();
            }
