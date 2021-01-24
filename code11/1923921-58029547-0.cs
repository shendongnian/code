C#
try
            {
                SqlCommand sqlCommand = new SqlCommand("select top 1 image from extra where product_id = @product_id", connection);
                sqlCommand.Parameters.Add(new SqlParameter("@product_id", id));
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        img = new
                        {
                            image = sqlDataReader["image"] == DBNull.Value ? null : "data:image/png;base64," + Convert.ToBase64String((byte[])sqlDataReader["image"])
                        };
                        connection.Close();
                        return img;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new { error = true, message = "Unknown error in image getting" };
