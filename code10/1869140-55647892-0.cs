         private string get_code_pays(string nom_pays)
        {
            string Query1 = "SELECT * FROM Pays  WHERE Pays='" + PaysCmBx0.Text + "'";
            string Code_Pays="";
            SqlCommand cmd1 = new SqlCommand(Query1, con);
            SqlDataReader myRead;
            try
            {
                con.Open();
                myRead = cmd1.ExecuteReader();
                while (myRead.Read())
                {
                     Code_Pays = myRead["Alpha2"].ToString();
                    PaysCmBx0.SelectedIndex.Equals(Code_Pays);
                }
                con.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            return Code_Pays;
        }
