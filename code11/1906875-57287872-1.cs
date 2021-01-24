    public int Create(FamilyModel model)
    {
        try
        {
            var XML = model.GetEnrolmentFromModel().Serialize();
            var RV = -99;
            var familySent = 0;
            using (SqlConnection cnx = new SqlConnection(connexionString))
            using (SqlCommand cmd = new SqlCommand("[dbo].[uspConsumeEnrollments]", cnx))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                
                var returnParameter = new SqlParameter("@RV", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.Output;
                
                cmd.Parameters.Add(returnParameter);
                
                var xmlParameter = new SqlParameter("@XML", XML);
                xmlParameter.DbType = DbType.Xml;
                
                cmd.Parameters.Add(xmlParameter);
                
                var familySentParameter = new SqlParameter("@FamilySent", SqlDbType.Int);
                familySentParameter.Value = 0;
                familySentParameter.Direction = ParameterDirection.Output;
                
                cmd.Parameters.Add(familySentParameter);
                
                cnx.Open();
                
                List<string[]> res = new List<string[]>();
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                res.Add(new string[2]{reader.GetName(i),reader[i].ToString());
                            }
                        }
                    }
                }
                
                // then here get all of your data you need
                
            }
            cnx.Close();
            return RV;
        }
        catch (SqlException e)
        {
        }
    }
