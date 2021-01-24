            public int getLatestBill()
        {
            DataTable dt = new DataTable();
            try
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "getLatestBill";
                SqlDataAdapter adapt = new SqlDataAdapter(command);
                connect.Open();
                adapt.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connect.Close();
            }
            return Convert.ToInt32(dt.Rows[0][0]);
        }
