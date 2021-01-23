    protected void Add_Click(object sender, EventArgs e)
    {
        string hesap = Label1.Text;
        string musteriadi = DropDownList1.SelectedItem.Value;
        string avukat = DropDownList2.SelectedItem.Value;
        string strConnectionString = ConfigurationManager.ConnectionStrings["SqlServerCstr"].ConnectionString;
        using (SqlConnection myConnection = new SqlConnection(strConnectionString))
        {
            myConnection.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO AVUKAT VALUES (@MUSTERI, @AVUKAT, @HESAP)", myConnection))
            {
                cmd.Parameters.AddWithValue("@HESAP", hesap);
                cmd.Parameters.AddWithValue("@MUSTERI", musteriadi);
                cmd.Parameters.AddWithValue("@AVUKAT", avukat);
                cmd.Connection = myConnection;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        // Add a javascript alert to let the user know that the same HESAP value already exists.
                    }
                    else
                    {
                        // Rethrow the exception.
                        throw;
                    }
                }
            }
            Response.Redirect(Request.Url.ToString());
            myConnection.Close();
        }
    }
