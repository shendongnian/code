    SqlConnection conn = new SqlConnection("ConnectionString");
            conn.Open();
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM table_name", conn);
            Int32 count = Convert.ToInt32(comm.ExecuteScalar());
            if (count > 0)
            {
                lblCount.Text = Convert.ToString(count.ToString()); //For example a Label
            }
            else
            {
                lblCount.Text = "0";
            }
            conn.Close(); //Remember close the connection
