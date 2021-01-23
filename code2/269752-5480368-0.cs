        using (SqlCeConnection con = new SqlCeConnection(strConn))
        {
            con.Open();
            using (SqlCeCommand cmd = new SqlCeCommand("insert into CustTable(ID,   Name) values (@Val1, @val2)",con))
            {
                cmd.Parameters.AddWithValue("@Val1", customer.RequestID);
                cmd.Parameters.AddWithValue("@Val2", customer.CAID);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }
