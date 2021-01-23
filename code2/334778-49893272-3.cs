     DBManagement c = new DBManagement();
    public DataSet GetGetTestList(int testId)
            {
                Parameter[] p = new Parameter[1]; 
                 
                p[0].ParameterName = "@TestId";
                p[0].Value = testId;
                p[0].DbType = DbType.Int32;
              
                return c.ExecuteProcedure(Procedures.TestDetails, CommandType.StoredProcedure,p);
            }
