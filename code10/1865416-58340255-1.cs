public class Employee
{
     public int Id { get; set; }
     public string Name { get; set; }
}
public class Programmer 
{
     [ForeignKey(nameof(Employee))]
     public  int Id { get ; set ; }
     public virtual Employee {get;set;}
     double HRate { get; set; }
     
}
public class Engineer: Employee
{
     [ForeignKey(nameof(Employee))]
     public  int Id { get ; set ; }
     public virtual Employee {get;set;}
     double MRate { get; set; }
}
