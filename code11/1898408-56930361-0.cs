    MySqlConnection con=null;
    try
    {
    	string myConnectionString = "server=localhost;database=test;uid=root;pwd=root;";
    	OpenFileDialog openFileDialog1 = new OpenFileDialog();
    	openFileDialog1.Filter = "Image files | *.jpg";
    	if (openFileDialog1.ShowDialog() == DialogResult.OK)
    	{
    
    		con = new MySqlConnection(myConnectionString);
    		string FileName = openFileDialog1.FileName;
    		FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
    		BinaryReader br = new BinaryReader(fs);
    		byte[] ImageData = br.ReadBytes((int)fs.Length);
    		br.Close();
    		fs.Close();
    		string CmdString = "INSERT INTO images(id, name, data) VALUES(@id, @name, @data)";
    		MySqlCommand cmd = new MySqlCommand(CmdString, con);
    		cmd.Parameters.Add("@id", MySqlDbType.Int32);
    		cmd.Parameters.Add("@name", MySqlDbType.VarChar, 45);
    		cmd.Parameters.Add("@data", MySqlDbType.LongBlob);
    		cmd.Parameters["@id"].Value = 5;
    		cmd.Parameters["@name"].Value = textBox1.Text;
    		cmd.Parameters["@data"].Value = ImageData;
    			  
    		con.Open();
    		int RowsAffected = cmd.ExecuteNonQuery();
    		if (RowsAffected > 0)
    		{
    			MessageBox.Show("Image saved sucessfully!");
    		}
    	   
    	}
    	else
    	{
    		MessageBox.Show("Incomplete data!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
    	}
    }
    catch (Exception ex)
    {
    	MessageBox.Show(ex.Message);
    }
    finally
    {
    	if (con!=null && con.State == ConnectionState.Open)
    	{
    		con.Close();
    	}
    }
