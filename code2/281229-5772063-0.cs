 SqlParameter[] parameters = { 
                new SqlParameter("@param1", SqlDbType.NVarChar, 50),
                new SqlParameter("@param2", SqlDbType.VarChar, 100),
                new SqlParameter("@param3", SqlDbType.VarChar, 100),
                new SqlParameter("@param4", SqlDbType.VarChar, 100),
                new SqlParameter("@param5", SqlDbType.VarChar, 100),
                new SqlParameter("@param6", SqlDbType.VarChar, 100)
            };
            parameters[0].Value = strFname;
            parameters[1].Value = strLname;
            .........
            .........
            [all the parameters you need]
