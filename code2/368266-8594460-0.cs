        public List<City> GetCities()
        {
            try
            {
                List<City> cityList = new List<City>();
                using (sqlCon = new SqlConnection(Database.GetConnectionString()))
                {
                    sqlCmd = new SqlCommand("sp_Cities", sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Mode", 1);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (sqlCon.State != System.Data.ConnectionState.Open)
                    {
                        sqlCon.Open();
                    }
                    sqlReader = sqlCmd.ExecuteReader();
                    using (sqlReader)
                    {
                        if (sqlReader.HasRows)
                        {
                            City c = new City();
                            
                            while (sqlReader.Read())
                            {
                                c = new City ();
                                c.ID = Convert.ToInt32(sqlReader["ID"]);
                                c.Name = Convert.ToString(sqlReader["Name"]);
                                
                                cityList.Add(c);
                            }
                        }
                    }
                }
                
                return cityList;
            }
            catch (Exception)
            {
                throw;
            }
        }
