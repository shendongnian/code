           con = new OleDbConnection(cs);
           con.Open();
           cmd = new OleDbCommand(cs);
           string cb = "insert into colorcodes(color,pic) VALUES ('" + colorcb.Text + "','" + openFileDialog1.FileName + "'  )";
           cmd = new OleDbCommand(cb);
           cmd.Connection = con;
           cmd.ExecuteNonQuery();
           con.Close();
           MessageBox.Show("image Saved Successfully");
         }
         catch (Exception ex)
         {
           MessageBox.Show(ex.Message);
         }
