    using (var ctx = new DBEntities())
    {
        var idParam = new SqlParameter { ParameterName = "Id",Value = 1};
                
        //Get employee by id
        var employeeList = ctx.Database.SqlQuery<Employee>("exec GetEmployeById @Id ", idParam).ToList<Employee>();
    
        foreach (employee emp in employeeList)
           Console.WriteLine("Employee Name: {0}",emp.Name);
      }       
