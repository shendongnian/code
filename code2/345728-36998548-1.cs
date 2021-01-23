            var p = new OracleDynamicParameters();
            p.Add("param1", pAuditType);
            p.Add("param2", pCommnId);
            p.Add("outCursor", dbType: OracleDbType.RefCursor, direction: ParameterDirection.Output);
            using (var multi = cnn.QueryMultiple("procedure_name", param: p, commandType: CommandType.StoredProcedure))
            {
                var data = multi.Read();
                return data;
            }
