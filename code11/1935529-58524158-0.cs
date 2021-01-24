            if (reader["Client"] != DBNull.Value)
            {
                obj.Client = (string)reader["Client"];
            }
            if (reader["PolicyNo"] != DBNull.Value)
            {
                obj.PolicyNo = (string)reader["PolicyNo"];
            }
            else
            {
                return null;
            }
            if (reader["PolicyType"] != DBNull.Value)
            {
                obj.PolicyType = (short)reader["PolicyType"];
            }
