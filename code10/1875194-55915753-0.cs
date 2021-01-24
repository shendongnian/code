    class School
    {
         public int Id {get; set;}
         public string Name {get; set;}
         ...
         // every School has zero or more Students (one-to-many)
         public virtual ICollection<Student> Students {get; set;}
    }
    class Student
    {
         public int Id {get; set;}
         public string Name {get; set;}
         ...
         // Every Student attends exactly one School, using foreign key:
         public int SchoolId {get; set;}
         public virtual School School {get; set;}
    }
