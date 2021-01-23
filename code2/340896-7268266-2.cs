     using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["AspnetdbconnectionString"].ConnectionString))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "SELECT * FROM ...";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            // do stuff
                        }
                    }
                }
            }
