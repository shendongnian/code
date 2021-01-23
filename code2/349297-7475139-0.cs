    interface IService {  
      void Do(string parameter);
    }
    
    class SomeService : IService {
      private ISomething smth;  
    
      public void SomeService()
      {
        smth = CreateSomething();
      }
    }
