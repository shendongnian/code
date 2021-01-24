    public List<Employee> GetEmployeeList(int EmpId, int DeptId)
    {
       using (var command = Database.GetDbConnection().CreateCommand())
       {
          command.CommandText = "myStoredProcedureName";
          command.CommandType = CommandType.StoredProcedure;
          Database.OpenConnection();
          using (var result = command.ExecuteReader())
          {
          }
       }
    }
