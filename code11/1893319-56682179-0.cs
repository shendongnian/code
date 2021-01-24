    private void AddOrUpdateCustomer(Customer customer)
    {
        // Data validity tests omitted for brevity - but you should ensure 
        // customer has all it's properties set correctly.
        // Readable code - Isn't that much easier to debug?
        var sql = @"
            IF NOT EXISTS (
                SELECT * 
                FROM [Customers] 
                WHERE Customer_Name = @Name 
            ) -- You where missing this closing parentesis
            BEGIN 
            INSERT INTO [Customers](Customer_Name, Cellphone_Number, Telephone_Number, Alternative_Number) 
            VALUES(@Name, @Cell, @Telephone, @Alternative) 
            END ELSE BEGIN 
            UPDATE [Customers] 
            SET Customer_Name = @Name, 
            Cellphone_Number = @Cell, 
            Telephone_Number = @Telephone, 
            Alternative_Number = @Alternative 
            END"; 
        
        // connectionString should be obtained from configuration file
        using(var con = new SqlConnection(connectionString))
        {
            using(var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add(@"Name", SqlDbType.NVarChar).Value = customer.Name;
                cmd.Parameters.Add(@"Cell", SqlDbType.NVarChar).Value = customer.Cellphone;
                cmd.Parameters.Add(@"Telephone", SqlDbType.NVarChar).Value = customer.Telephone;
                cmd.Parameters.Add(@"Alternative", SqlDbType.NVarChar).Value = customer.AlternativeNumber;
                
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
    
