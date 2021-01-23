    public class Employee: IEmployee 
    {
       public static int numberOfEmployees;
    
       private int counter;
    
       private string name;
    
       // Read-write instance property:
       public string Name
       {
          get
          {
             return name;
          }
          set
          {
             name = value;
          }
       }
    
       // Read-only instance property:
       public int Counter
       {    
          get    
          {    
             return counter;
          }    
       }
    
       // Constructor:
       public Employee()
       {
          counter = ++counter + numberOfEmployees;
       }
    }  
