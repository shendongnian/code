    using (SqlConnection con = new SqlConnection(MyConnString))
    {
        con.Open(); 
        using (SqlCommand sqlCmd = new SqlCommand("SELECT DATE_A FROM Donnees_Accueil", con)) 
        {
            using (SqlDataReader sqlReader = sqlCmd.ExecuteReader())
            {
                StringBuilder sb = new StringBuilder();
                while (sqlReader.Read())
                {
                    sb.Append(Convert.ToString(sqlReader["Date_A"])); 
                }  
                hourA.Text = sb.ToString(); 
            } 
        }
    }
