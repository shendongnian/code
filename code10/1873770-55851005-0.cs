     using (var multi = _oracleConnection.QueryMultiple("procedure_name", param: p, commandType: CommandType.StoredProcedure))
            {
                List<dynamic> list1 = multi.Read<dynamic>().AsList();
                List<dynamic> list2 = multi.Read<dynamic>().AsList();
                List<dynamic> list3 = multi.Read<dynamic>().AsList();
               
                ...
            }
