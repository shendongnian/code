        public Boolean BeforeToday(DateTime dateInQuestion)
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    String sql = @"SELECT CONVERT(bit, CASE WHEN getdate() > @dateParameter THEN 1 ELSE 0 END) AS BeforeToday";
                    var result = conn.ExecuteScalar<Boolean>(sql, new { dateParameter = dateInQuestion });
                    return result;
                }
            }
            catch (Exception)
            {
                return dateInQuestion < DateTime.Now;
            }
        }
