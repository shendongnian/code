    class School
    {
        public int Id {get; set;}
        ...                     
        // every School has zero or more Students (one-to-many)
        public virtual ICollection<Student> Students {get; set;}
    }
    class Student
    {
        public int Id {get; set;}
        ...   
        // Every Student studies at one School, using foreign key
        public int SchoolId {get; set;}
        public virtual School School {get; set;}
    }
    public SchoolContext : DbContext
    {
        public DbSet<School> Schools {get; set;}
        public DbSet<Student> Students {get; set;}
    }
