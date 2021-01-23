     public interface IEmployee
     {
     }
     public class Developer : IEmployee
     {
     }
     public class Tester : IEmployee
     {
     }
     public interface IManager
     {
     }
     public class HRManager : IManager
     {
     }
   
     public class ProjectManager : IManager
     {
     }
     
     public interface IFactory()
     {
          IEmployee CreateEmployee();
          IManager CreateManager();
     }
     public class ConcreteFactory1 : IFactory
     {
          public IEmployee CreateEmployee()
          {
               return new Developer();
          }
          public IEmployee CreateManager()
          {
               return new HRManager();
          }
     }
     public class ConcreteFactory2 : IFactory
     {
          public IEmployee CreateEmployee()
          {
               return new Tester();
          }
          public IEmployee CreateManager()
          {
               return new ProjectManager();
          }
     }
