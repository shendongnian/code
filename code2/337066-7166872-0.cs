    class EmployeeFactory
    {
      public static Employee NewEmployee(EmployeeType type)
      {
         Employee emp = null;
         switch (type)
         {
            case EmployeeType.Manager :
               emp = new Manager();
               break;
            case EmployeeType.Salesman :
               emp = new Salesman();
               break;
         }
         return emp;
      }
    }
