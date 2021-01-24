     using (MySqlDataReader oReader = cmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    Label label1 = new Label();
                    label1.Text = oReader.GetString("Nom_Utilisateur");
                    Controls.Add(label1); //controls can be panel on your page
    
                     other labels
    
                }
    
    
            }
