    public class DisposableWrapper<T> : IDisposable {
      public T Item { get; private set; }
      public DisposableWrapper(T item) { Item = item; }
      public void Dispose() {
        using (Item as IDisposable) { }
        Item = default(T);
      }
    }
    public static class DisposableWrapperExtensions {
      public static DisposableWrapper<T> AsDisposable<T>(this T item) {
        return new DisposableWrapper<T>(item);
      }
    }
    public class EngineDriver<T> where T : IEngine, new() {
      public void GetThingsDone() {
        using (var driver = new T().AsDisposable()) {
          driver.Item.DoWork();
        }
      }
    }
