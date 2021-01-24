    List<dynamic> hosts = new List<dynamic>();
    using (SqlCommand command = conn.CreateCommand())
    {
        command.CommandText = "SELECT [DeviceSeq], [DeviceName], [SerialNumber], [Premise], [InsertDate], [VersionNumber], [LastUpdateDate], [IsDeleted] FROM [ITAM].[dbo].[AllDevices] WHERE DeviceName LIKE @filter OR SerialNumber = @filter";
        var param = new SqlParameter("filter", System.Data.SqlDbType.VarChar);
        param.Value = "%YOUR_FILTER_VALUE%";
        command.Parameters.Add(param);
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                dynamic h = new ITAMHost()
                {
                    DeviceSeq = reader[0].ToString(),
                    DeviceName = reader[1].ToString(),
                    SerialNumber = reader[2].ToString(),
                    Premise = reader[3].ToString(),
                    InsertDate = reader[4].ToString(),
                    VersionNumber = reader[5].ToString(),
                    LastUpdateDate = reader[6].ToString(),
                    IsDeleted = reader[7].ToString(),
                };
                hosts.Add(h);
            }
        }
    }
