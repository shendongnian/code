    public class DisposableCollectionWrapper<D> : IDisposable
    where D : IDisposable {
      private readonly IEnumerable<D> _disposables;
      public DisposableCollectionWrapper(IEnumerable<D> disposables) {
        _disposables = disposables;
      }
      public void Dispose() {
        if (_disposables == null) return;
        foreach (var disposable in _disposables) {
          disposable.Dispose();
        }
      }
    }
    public static class CollectionExtensions {
      public static IDisposable AsDisposable<D>(this IEnumerable<D> self)
      where D : IDisposable {
        return new DisposableCollectionWrapper<D>(self);
      }
    }
