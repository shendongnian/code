    using System;
    namespace Closures {
      public static class WeakReferenceExtensions {
        /// <summary> returns null if target is not available. Safe to call, even if the reference is null. </summary>
        public static TTarget TryGetTarget<TTarget>(this WeakReference<TTarget> reference) where TTarget : class {
          TTarget r = null;
          if (reference != null) {
            reference.TryGetTarget(out r);
          }
          return r;
        }
      }
      public static class ObservableExtensions {
        public static IDisposable WeakSubscribe<T, U>(this IObservable<U> source, T target, Action<T, U> action)
          where T : class {
          var weakRef = new WeakReference<T>(target);
          var r = source.Subscribe(u => {
            var t = weakRef.TryGetTarget();
            if (t != null) {
              action(t, u);
            }
          });
          return r;
        }
      }
    }
