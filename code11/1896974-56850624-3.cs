    private static List<Department> departments = new List<Department>
    {
        new Department
        {
            Id = 1,
            Name = "sales",
            Dependencies = new List<int>{ 2 }
        },
        new Department
        {
            Id = 2,
            Name = "accounts",
            Dependencies = new List<int>{ 3 }
        },
        new Department
        {
            Id = 3,
            Name = "marketing",
            Dependencies = new List<int>{ 1 }
         },
         new Department
         {
            Id = 4,
            Name = "finance",
            Dependencies = new List<int>{ 1 }
         }
     };
