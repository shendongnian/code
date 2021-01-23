    using(SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT  COCOPER  FROM HR11COMP  where cocode = @sComCode order by COCPER";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@sComCode", sComCode));
                    object cocoper = cmd.ExecuteScalar();
                    if (cocoper != null)
                         txtYear.DataBinding.Add("Text", cocoper.ToString(), "COCPER");
                }
            }
