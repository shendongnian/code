    class IDEmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee first, Employee second)
        {
          return (first.ID == second.ID);
        }
        public int GetHashCode(Employee employee)
        {
           return employee.ID
        }
    }
...
    var intersection = A.Intersect(B, new IDEmployeeComparer ()).ToArray();
