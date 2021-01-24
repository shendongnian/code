    private void Button1_Click(object sender, EventArgs e)
    {
    
        try
        {
            string connetionString = @"Server==localhost;Database=my_projects;User ID=root;Password=123456";
            using(MySqlConnection cnn = new SqlConnection(connetionString))
            {
                cnn.Open();
                MessageBox.Show("Connection Open  !");
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show("Cannot open connection: Reasong:" + ex.Message);
        }
    
    }
