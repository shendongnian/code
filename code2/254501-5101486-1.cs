      public static void UpdateEmployee(Employee employee)
      {
          using (HRDataContext dataContext = new HRDataContext())
          {
              //attach to datacontext
              employee.Detach();
                dataContext.Employees.Attach(employee);
              //save changes
                dataContext.SubmitChanges();
         }
     }
