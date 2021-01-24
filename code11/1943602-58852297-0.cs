    string connetionString = null;
            MySqlConnection cnn ;
			connetionString = "server=localhost;database=testDB;uid=root;pwd=abc123;";
            cnn = new MySqlConnection(connetionString);
            try
            {
                cnn.Open();
                MessageBox.Show ("Connection Open ! ");
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
