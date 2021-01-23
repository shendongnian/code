                using (SqlCommand cmd = new SqlCommand("SELECT SUM(Paied) As SumOfPaid FROM Debt", new SqlConnection(Program.ConnectionString))) 
            { 
                cmd.Connection.Open(); 
                SqlDataReader myReader = cmd.ExecuteReader(); 
                while (myReader.Read()) 
                {
                    TotalPaiedAll = Convert.ToDecimal(myReader["SumOfPaid"].ToString()); 
                } 
                cmd.Connection.Close(); 
            }
