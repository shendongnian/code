    TYPE t_stringlist IS TABLE OF VARCHAR2(4000);
            string[] values = new string[] { "AAA", "BBB" };
            
            OracleParameter parameter = new OracleParameter();
            parameter.Name = "my_param";
            parameter.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
            parameter.OracleDbType = OracleDbType.Varchar2;
            parameter.ArrayBindSize = new int[values.Length];
            parameter.ArrayBindStatus = new OracleParameterStatus[values.Length];
            parameter.Size = values.Length;
            for (int i = 0; i &lt; values.Length; ++i)
            {
                parameter.ArrayBindSize[i] = 4000;
                parameter.ArrayBindStatus[i] = OracleParameterStatus.Success;
            }
            parameter.Value = values;
