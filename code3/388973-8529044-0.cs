    cmd.Parameters.Add(
        new SqlParameter
        {
            ParameterName = "@ListOfIds",
            SqlDbType = SqlDbType.Xml,
            Value = new SqlXml(idList.CreateReader())
        });
