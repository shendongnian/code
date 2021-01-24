            String cs = @"Data Source=LENOVO-G510;Initial Catalog=Nelna2;Persist Security Info=True;User ID=sa;Password=123";
        protected void Save_Click(object sender, EventArgs e)
        {
            // SqlConnection con = new SqlConnection(cs);
            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    SqlCommand command5 = new SqlCommand("insert into MonthEnd (month,year,ProcessedDate) values (@month2,@year2,@ProcessedDate2) ", con);
                    command5.Parameters.AddWithValue("@month2", NextMonth);
                    command5.Parameters.AddWithValue("@year2", NextYear);
                    command5.Parameters.AddWithValue("@ProcessedDate2", ProcessedDate);
                    command5.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
