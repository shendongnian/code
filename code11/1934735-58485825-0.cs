        string queryStr = "SELECT * from abba.osoba where ID=@id";
        string constring = "datasource=localhost;port=3306;username=root;password=";
        MySqlConnection conDataBase = new MySqlConnection(constring);
        MySqlCommand cmdDataBase = new MySqlCommand(queryStr, conDataBase);
        //important! do not concatenate values into SQL strings. Put a parameter then populate it with a value
        cmdDAtaBase.Parameters.Add("@id", MySqlDbType.Int32 ).Value = trenutniID;
        try
        {
            MySqlDataAdapter sda = new MySqlDataAdapter();
            sda.SelectCommand = cmdDataBase;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count ==0)
              MessageBox.Show("Unknown ID " + trenutniID);
            else{
              idField.Text = dt.Rows[0]["id"].ToString(); //you could use a "string" name of column here instead of numbers like 0. it's marginally easier to read
              oib.Text = dt.Rows[0][1].ToString(); //or "oib" etc? 
              name.Text = dt.Rows[0][2].ToString();
              lastname.Text = dt.Rows[0][3].ToString();
              place.Text = dt.Rows[0][4].ToString();
              adress.Text = dt.Rows[0][5].ToString();
              no.Text = dt.Rows[0][6].ToString();
              mail.Text = dt.Rows[0][7].ToString();
           }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
