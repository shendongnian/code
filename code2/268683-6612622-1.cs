    protected void btndel_Click(object sender, EventArgs e)
        {
    
            SqlConnection conn;
            SqlCommand cmd;
            conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename='C:\\Users\\THEGIRL\\Documents\\Visual Studio 2008\\WebSites\\WebSite72\\App_Data\\Database.mdf';Integrated Security=True;User Instance=True");
            conn.Open();
            cmd = new SqlCommand("Delete from logintable where username='"+txtdeluname.Text+"'",conn);
            lbldel.Text = "Record is deleted";
            cmd.ExecuteNonQuery();
            conn.Close();
        }
