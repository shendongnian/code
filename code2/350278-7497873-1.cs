    SqlParameter moFrom1Param = new SqlParameter("@MoFrom1", dTOForwarding.MoFrom1 == null ? DBNull.Value : dTOForwarding.MoFrom1);
                moFrom1Param.IsNullable = true;
                moFrom1Param.Direction = ParameterDirection.Input;
                moFrom1Param.SqlDbType = SqlDbType.DateTime;
                cmd.Parameters.Add(moFrom1Param);
