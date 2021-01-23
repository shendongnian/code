        using (SqlCeConnection con = new SqlCeConnection(strConn))
        {
            con.Open();
            using (SqlCeCommand cmd = new SqlCeCommand("insert into CustTable(ID,   Name) values (@Val1, @val2)",con))
            {
                cmd.Parameters.AddWithValue("@Val1", customer.ID);
                cmd.Parameters.AddWithValue("@Val2", customer.Name);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }
