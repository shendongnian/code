    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection (
        "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:customers.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
    
         try
         {
              SqlDataReader dReader;
              SqlCommand cmd = new SqlCommand();
              cmd.Connection = connection;
              cmd.CommandType = CommandType.Text;
              cmd.CommandText ="Select distinct [Name] from [Names]" +
              " order by [Name] asc";
             connection.Open();
    
             dReader = cmd.ExecuteReader();
             if (dReader.HasRows == true)
             {
                  while (dReader.Read())
                  //Names collection is a combo box.
                  namesCollection.Add(dReader["Name"].ToString());
    
             }
             else
             {
                  MessageBox.Show("Data not found");
             }
               dReader.Close()
             TextBox1.Text = "connected";
         }
         catch (Exception)
         {
             TextBox1.Text = " not connected";
         }
     }
    
    Hope that helps................
