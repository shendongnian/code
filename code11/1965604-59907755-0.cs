        int? employeeCount = null;
        string deptName="IT";
        
        // Use Microsoft.Data.SqlClient namespace for SqlParameter.Visual studio will suggest  "system.data.sqlclient" which does not work
        var deptNameSQLParam = new Microsoft.Data.SqlClient.SqlParameter("@Dept", deptName);
        var employeeCountSQLParam = new Microsoft.Data.SqlClient.SqlParameter("@EmpCount", SqlDbType.Int) { Direction = ParameterDirection.Output }; 
        Database.ExecuteSqlRaw("exec dbo.usp_GetEmpCountByDept @Dept={0}, @EmpCount={1} out", deptNameSQLParam, employeeCountSQLParam);
                   
         if (employeeCountSQLParam.Value != DBNull.Value)
         {
            employeeCount = (int)employeeCountSQLParam.Value;
         }
