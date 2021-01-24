    public abstract class Employee
    {
       public string Name { get; set; }
       public double Salary { get; set; }
       public abstract void IncreaseSalary(double rate);
    }
