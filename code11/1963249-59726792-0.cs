MySqlCommand cmdSel = new MySqlCommand("SELECT * FROM tokens WHERE token = " + int.Parse(passbox.Text), dbCon);
int sqlkey=0;
            MySqlDataReader dbRead = cmdSel.ExecuteReader();
            if (dbRead.Read())
              {
                sqlkey = int.Parse(dbRead["token"].ToString()); 
               
                }
        reader.close();
       if (keyint == sqlkey)
                {
                    using (MySqlCommand delTok = new MySqlCommand("DELETE FROM tokens WHERE token = " + keyint, dbCon))
                       {
                    
                        delTok.ExecuteNonQuery(); 
                       
                    
                    try
                    {
                        dbCon.Close();
                        loading loading = new loading();
                        loading.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                  }
}
