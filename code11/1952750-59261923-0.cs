using System;
struct Employee
{
    public int Id { get; set; }
    public string FullName { get; set; }
}
public class MyClass
{
    Employee obj = new Employee();
        
    public MyClass()
    {
            Console.WriteLine(obj.FullName);
    }
}
