            using (IDbConnection connection = Connector.CreateConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "<command text>";
                var paramA = command.CreateParameter();
                paramA.ParameterName = "ParameterA";
                paramA.DbType = DbType.Int32;
                command.Parameters.Add(paramA);
                var paramB = command.CreateParameter();
                paramB.ParameterName = "ParameterB";
                paramB.DbType = DbType.String;
                command.Parameters.Add(paramB);
                var paramC = command.CreateParameter();
                paramC.ParameterName = "ParameterC";
                paramC.DbType = DbType.Decimal;
                command.Parameters.Add(paramC);
                command.Prepare();
                foreach (ProcedureArgs args in m_procedureArgs)
                {
                    paramA.Value = args.ParamA;
                    paramB.Value = args.ParamB;
                    paramC.Value = args.ParamC;
                    command.ExecuteNonQuery();
                }
            }
