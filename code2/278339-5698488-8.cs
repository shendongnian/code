    public class MainClass
    {
       public static void Main()
       {    
          Console.Write("Enter number of employees: ");
    
          string s = Console.ReadLine();
    
          Employee.numberOfEmployees = int.Parse(s);
    
          Employee e1 = new Employee();
    
          Console.Write("Enter the name of the new employee: ");
    
          e1.Name = Console.ReadLine();  
    
          Console.WriteLine("The employee information:");
    
          Console.WriteLine("Employee number: {0}", e1.Counter);
    
          Console.WriteLine("Employee name: {0}", e1.Name);    
       }    
    }
