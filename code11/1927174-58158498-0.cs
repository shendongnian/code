    public interface IEngine
    {
      void SomeMethod();
    }
    public class Car
    {
      private class Engine : IEngine
      {
        void IEngine.SomeMethod()
        {
          throw new NotImplementedException();
        }
      }
      private readonly IEngine _engine;
      public Car()
      {
        _engine = new Engine();
      }
      public Car(IEngine engine)
      {
        _engine = engine;
      }
    }
