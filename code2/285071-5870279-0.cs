                IDParam.ParameterName = "MaxID";
                IDParam.OleDbType = OleDbType.BigInt;
                IDParam.Value = MaxID;
                dbComm.Parameters.Add(IDParam);
                dbComm.Parameters.AddWithValue("ListName", ListName);
                dbComm.Parameters.AddWithValue("ListValue", strValue);
