    public void SaveATLast()
    {
        cnx.Close();
        string image = pictureBox1.Text;
        if (CmbImo.SelectedIndex != -1 && textBox1.Text!="" && textBox3.Text != "")
        { 
            cnx.Open();
            using (MemoryStream ms = new MemoryStream())
            {
                pictureBox1.Image.Save(ms,pictureBox1.Image.RawFormat);
                byte[] bimage = new byte[ms.Length];
                ms.Write(bimage, 0, (int)ms.Length);
                //DB Opeartions stuff
                SqlCommand cmd = new SqlCommand(" insert into Baa ( Imo , Height  ,Name , ImageB,BPlug,APlug) values ( @Imo, @Height , @Name , @imgdata,@BPlug,@APlug)", cnx);
                cmd.Parameters.AddWithValue("@Imo", SqlDbType.Int).Value = CmbImo.SelectedItem.ToString();
                cmd.Parameters.AddWithValue("@Height", SqlDbType.VarChar).Value = textBox3.Text;
                cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = textBox1.Text;
                cmd.Parameters.AddWithValue("@imgdata", SqlDbType.Image).Value = bimage;
                cmd.Parameters.AddWithValue("@BPlug", SqlDbType.VarChar).Value = textBox4.Text;
                cmd.Parameters.AddWithValue("@APlug", SqlDbType.Int).Value = textBox2.Text;
                comboBox1.SelectedItem.ToString();
                cmd.ExecuteNonQuery();
                cnx.Close();
            }
        
            //this.Close();
            textBox1.Clear();
            textBox3.Clear();
            textBox2.Clear();
            textBox4.Clear();
            pictureBox1.Image = null;
        }
        else
        {
            MessageBox.Show("please Do Fill all Textboxes !!");
        }
    }    
