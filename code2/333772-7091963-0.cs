    class EmployeeComparer : IEqualityComparer<Employeees> {
    
      public bool Equals(Employeees x, Employeees y) {
        return x.Id == y.Id;
      }
    
      public int GetHashCode(Employeees employee) {
        return employee.Id.GetHashCode();
      }
    
    }
