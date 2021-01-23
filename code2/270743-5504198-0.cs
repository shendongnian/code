    public class Resource : IDisposable {
      // your resource cannot be instantiated outside this assembly
      internal Resource() { }
      public void Dispose() {}
    }
    public abstract class ShortLivedResource<T> where T : IDisposable {
      public void Use(Action<T> action) {
        using (var resource = CreateResource()) {
          action(resource);
        }
      }
      internal abstract T CreateResource();
    }
    public class ResourceFactory : ShortLivedResource<Resource> {
      internal override Resource CreateResource() {
        return new Resource();
      }
    }
