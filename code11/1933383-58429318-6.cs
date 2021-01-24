    public class Mssql<T> where T :class, IDepartment, new()
        {            
            public List<T> ReadTable()
            {
                string sqlcommand = "Select * from Bank; ";
                List<T> TheListofObject = new List<T>();
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    cnn.Open();
                    using (SqlCommand command = new SqlCommand(sqlcommand, cnn))
                    {
                        SqlDataReader dataReader;
                        try
                        {
                            dataReader = command.ExecuteReader();
    
                            while (dataReader.Read())
                            {
                                IDepartment Object = new T();
                                object ReturnObject = Object.GetAndReadValues(dataReader);                            
                                TheListofObject.Add((T)ReturnObject);
                            }                        
                            return TheListofObject;
                        }
                        //Error handling with th DB must be handeld correctly with the specific error
                        catch (Exception ex)
                        {
                            throw;
                        }
                        dataReader.Close();
                    }
                    cnn.Close();
                }
    
            }
    
        }
