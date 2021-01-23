    public interface IEmployee
    {
     void Save(Employee e);
     bool Validate(Employee e);
    }
    
    public class EmployeeController:Controller, IEmployee
    {
      public void Save(Employee e){
      }
    
      [NonAction]
      public void Validate(Employee e){
      }
    }
