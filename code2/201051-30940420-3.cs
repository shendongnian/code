    public static List<string> GetCompletionList(string prefixText, int count)  
        {  
            return AutoFillProducts(prefixText);  
      
        }  
      
        private static List<string> AutoFillProducts(string prefixText)  
        {  
            using (SqlConnection con = new SqlConnection())  
            {  
                con.ConnectionString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;  
                using (SqlCommand com = new SqlCommand())  
                {  
                    com.CommandText = "select ProductName from ProdcutMaster where " + "ProductName like @Search + '%'";  
                    com.Parameters.AddWithValue("@Search", prefixText);  
                    com.Connection = con;  
                    con.Open();  
                    List<string> countryNames = new List<string>();  
                    using (SqlDataReader sdr = com.ExecuteReader())  
                    {  
                        while (sdr.Read())  
                        {  
                            countryNames.Add(sdr["ProductName"].ToString());  
                        }  
                    }  
                    con.Close();  
                    return countryNames;  
                }  
            }  
        }  
    
    
