    public List<DataClassName> GetDataList()
    {
        List<DataClassName> dataList = new List<DataClassName>();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "select * from TargetTableName";
        cmd.CommandType = CommandType.Text;
        try
        {
            using (SqlConnection connection = 
                       new SqlConnection("YourConnectionString"))
            {
                cmd.Connection = connection;
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataList.Add(
                            new DataClassName()
                                {
                                    Id = Convert.ToInt32(reader["ID"]),
                                    Name = Convert.ToString(reader["Name"])
                                    //Set all property according to your fields
                                });
                    }
                }
            }
        }
        catch(Exception ex_)
        {
            //Handle exception
        }
        return dataList;
    }
