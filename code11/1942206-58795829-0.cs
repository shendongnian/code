    public void AddCar(CarDTO c)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            if (con.State==ConnectionState.Closed)
                {                      
                    con.Open();   
                 }
             [Your code]
             con.Close();
        }
     }
