    public sealed class Resource : IDisposable {
      private Resource() { }
      public void Dispose() { ... }
      public void Use(Action<Resource> action) {
        using (var resource = new Resource()) {
          action(resource);
        }
      }
    }
