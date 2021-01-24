csharp
    public int ID { get; set; }
    public int Name { get; set; }
    public ICollection<Courses> Courses { get; set; }
And the Courses class will have to reference back to Person class. 1 course belong to one person 
csharp
    public int CourseID { get; set; }
    public string Name { get; set; }
    public Person Person { get;set; } 
Please let me know if you need any help
