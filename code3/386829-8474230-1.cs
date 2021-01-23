    public static string ConnectionString = 
        ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
    
    public Stream ShowEmployeeImage(int employeeNumber)
    {
        using (var conn = new SqlConnection(ConnectionString))
        {
            const string query = 
                "select Cust_Image from Cust_M_Tbl where Cust_FID = '@empNo'";
            using (var command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@empNo", employeeNumber.ToString());
                conn.Open();
    
                var image = command.ExecuteScalar();
    
                return image == null ? null : new MemoryStream((byte[]) image);
            }
        }
    }
