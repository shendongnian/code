     //no safety checks
     public static int Create<T>(object param)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                conn.Create<T>((T)param);
                return (int) (((T)param).GetType().GetProperties().Where(
                        x => x.CustomAttributes.Where(
                            y=>y.AttributeType.GetType() == typeof(Dapper.SimpleSave.PrimaryKeyAttribute).GetType()).Count()==1).First().GetValue(param));
            }
        }
