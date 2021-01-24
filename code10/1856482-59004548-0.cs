    public class Employee
    {
      public int EmpID { get; set;}
      public string Reference { get ; set{
          if(value == this.EmpID)
              throw new Exception("Email and Reference can't be same!");
      } }
      public string Name { get; set;}
    } 
