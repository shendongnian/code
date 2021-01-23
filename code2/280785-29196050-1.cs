    [webmethod]
    public List<Cars> getListOfCars(list<string> aData) 
    {
        SqlDataReader dr;
        List<Cars> carList = new List<Cars>();
             
             using (SqlConnection con = new SqlConnection(cn.ConnectionString))
             {
                using (SqlCommand cmd = new SqlCommand())
                {
                   cmd.CommandText = "spGetCars";
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Connection = con;
                   cmd.Parameters.AddWithValue("@makeYear", aData[0]);
                   con.Open();
                   dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                   if (dr.HasRows)
                   {
                      while (dr.Read())
                       {	
                           string carname=dr[“carName”].toString();
               string carrating=dr[“carRating”].toString();
                string makingyear=dr[“carYear”].toString();
               carList .Add(new Cars{carName=carname,carRating=carrating,carYear=makingyear}); 
            }
                    }
                }
              }
            return carList 
            }
