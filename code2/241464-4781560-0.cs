    public interface IRepository<T> where T : IModel
     {
        void GetAll<T>();
        void GetById<T>(int id);
     }    
     
     public interface IEmployeeRepo<T> : IRepository<T> where T : IModel
     {
        void DoSomethingEmployeeRelated();
     }
     public class BaseRepo : IRepository<T> where T : IModel
     {
        public void GetAll<T>()
        {
    
        }
        public void GetById<T>(int id)
        {
    
        }
     }
    
     
     public class EmployeeRepo : BaseRepo<Employee>,  IEmployeeRepo<Employee>
     {
        public void DoSomethingEmployeeRelated()
        {
    
        }
    
     }
    
     //My example model class
     public class Employee : IModel
     {
         public int Id {get;set;}
         public string Name {get;set;}
     }
