    SqlConnection conn = new 
    SqlConnection(DecryptString 
    (System.Configuration.ConfigurationManager.AppSettings["cn"], EncryptionKey2));
    conn.Open();
    SqlDataAdapter sda = new SqlDataAdapter("SELECT foodname,itemrate, 
    SUM(itemrate)[Sum] from darkwight_cart where foodname=@foodname)", conn);
    SqlCommand cmd = new SqlCommand();
    cmd.Parameters.AddWithValue("@foodname", "Pizza");
    conn.Close();
    DataTable dt = new DataTable();
    sda.Fill(dt);
    subtotallbl.Text = dt.Rows[0][0].ToString();
    conn.Dispose();
