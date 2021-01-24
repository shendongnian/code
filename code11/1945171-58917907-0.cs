    command.CommandText = "Insert into Package values (@param1,@param2@param3,@param4,@param5,@param6)";
    command.Parameters.Add("@param1",  SqlDbType.Int).Value = p.PackageID;
    command.Parameters.Add("@param2",  SqlDbType.NvarChar).Value = p.Name;
    command.Parameters.Add("@param3",  SqlDbType.DateTime).Value = p.DateFrom;
    command.Parameters.Add("@param4",  SqlDbType.DateTime).Value = p.DateTo;
    command.Parameters.Add("@param5",  SqlDbType.Bit).Value = bool.Parse(p.Internet.ToString());
    command.Parameters.Add("@param6",  SqlDbType.Bit).Value = bool.Parse(p.Telephone.ToString());
    command.ExecuteNonQuery();
