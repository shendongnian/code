    using (SqlConnection con = new SqlConnection(MyConnString))
    {
        con.Open(); 
        using (SqlCommand sqlCmd = new SqlCommand("SELECT DATE_A FROM Donnees_Accueil", con)) 
        {
            using (SqlDataReader sqlReader = sqlCmd.ExecuteReader())
            {
                if (sqlReader.Read())
                    hourA.Text = Convert.ToString(sqlReader["Date_A"]);
                else  
                    hourA.Text = "";
            } 
        }
    }
