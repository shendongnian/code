protected void Add_Click(object sender, EventArgs e) 
    { 
        string strConnectionString = ConfigurationManager.ConnectionStrings["SqlServerCstr"].ConnectionString; 
 
        SqlConnection myConnection = new SqlConnection(strConnectionString); 
        myConnection.Open(); 
 
 
        string hesap = Label1.Text.Trim(); 
        string musteriadi = DropDownList1.SelectedItem.Value; 
        string avukat = DropDownList2.SelectedItem.Value; 
        
        string strsql= "SELECT * FROM AVUKAT WHERE HESAP = " + hesap;
        SqlCommand com = new SqlCommand(strsql, myConnection);
        SqlDataReader dread = com.ExecuteReader(); 
        dread.read();
        if(dread.HasRows)
        {
           myConnection.Close();
           return;
        }
        SqlCommand cmd = new SqlCommand("INSERT INTO AVUKAT VALUES (@MUSTERI, @AVUKAT, @HESAP)", myConnection); 
 
        cmd.Parameters.AddWithValue("@HESAP", hesap); 
        cmd.Parameters.AddWithValue("@MUSTERI", musteriadi); 
        cmd.Parameters.AddWithValue("@AVUKAT", avukat); 
        cmd.Connection = myConnection; 
 
 
 
        SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection); 
        Response.Redirect(Request.Url.ToString()); 
        myConnection.Close(); 
    } 
