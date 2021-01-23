    public class EngineDriver<T> where T : IEngine, new() {
      public void GetThingsDone() {
        {
          T driver = new T();
          using (driver as IDisposable) {
            driver.DoWork();
          }
        }
        // do more stuff, can't access driver here ....
      }
    }
