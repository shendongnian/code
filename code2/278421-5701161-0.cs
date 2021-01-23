    public List<string> getCustomerTransaktions(string CustNr)
    {
        List<string> names = new List<string>();
        using (var cmd = new SqlCommand("select billing_name from [transaktions] where customer_nr = @customer_nr", Connect()))
        {
            cmd.Parameters.AddWithValue("@customer_nr", custNr);
            using (var er = cmd.ExecuteReader())
            {
                while(er.Read())
                {
                    names.Add((string)er["billing_name"]);
                }
            }
        }
        return names;
    }
