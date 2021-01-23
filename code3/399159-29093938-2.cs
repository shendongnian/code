           con = new OleDbConnection(cs);
           con.Open();
           cmd = new OleDbCommand("SELECT pic from  colorcodes where color= '" + colorcb.Text + "'  ", con);
           dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
           dr.Read();
           pictureBox2.ImageLocation = dr[0].ToString();
         }
         catch (Exception ex)
         {
           MessageBox.Show(ex.Message);
         }
