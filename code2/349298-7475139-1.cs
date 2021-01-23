    class Something
    {
    }
    interface IService {  
      void Do(string parameter);
      Something GetSomething();
    }
    
    class SomeService : IService {
      private Something smth;  
    
      public void SomeService()
      {
        smth = CreateSomething();
      }
      public void Do()
      {
        //
      }
      public Something GetSomething()
      {
        return smth;
      }
    }
