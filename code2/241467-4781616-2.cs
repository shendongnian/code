    public EmployeeRepository : GenericRepository<Employee>, IRepository<Employee>
    {
       // all regular methods (Find, Add, Remove) inherited - make use of them
       public Employee FindEmployeeByName(string name)
       {
          return FindAll().SingleOrDefault(x => x.Name == name);
          // or you could do: return FindSingle(x => x.Name == name);    
       }
    }
