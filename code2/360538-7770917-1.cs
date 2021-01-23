    class person {
    
      private Department _department = null;
    
      public Func<Department> GetDepartment { private get; set; }
    
      public string fname { get; set; }
      public string lname { get; set; }
    
      public Department d {
        get {
          if (_department == null) {
            _department = GetDepartment();
          }
          return _department;
        }
      }
    
    }
