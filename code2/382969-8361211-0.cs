        while (dr.Read())
        {
            var sdr = new SafeDataReader(dr);
            memberModel.ClientId = sdr.GetInt64("ClientId");
            memberModel.Id = sdr.GetInt64("EntityId");
            memberModel.Name = sdr.GetString("EntityName");
        }
        if (dr.NextResult())
        {
            while (dr.Read())
            {
                AddAttribute(memberModel, new SafeDataReader(dr));
            }
        }
        if (dr.NextResult())
        {
            while (dr.Read())
            {
                AddAlternateId(memberModel, new SafeDataReader(dr));
            }
        }
