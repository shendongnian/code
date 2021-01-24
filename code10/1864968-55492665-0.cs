`cs
public class User {
    public int Id { get; set; }
    public string Name { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public int DepartmentId { get; set; }
    public Department { get; set; }
}
public class Company {
    public int Id { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public ICollection<User> Users { get; set; }
}
Public class Department {
    public int Id { get; set; }
    public string Name { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    
    public ICollection<User> Users { get; set; }
}
`
later on we can see what error you are facing.
