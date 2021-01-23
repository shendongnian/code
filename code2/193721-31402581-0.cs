    public static class DisposableEnumerableExtensions {
        public static DisposableEnumerable<T> AsDisposable<T>(this IEnumerable<T> enumerable) where T : IDisposable {
            return new DisposableEnumerable<T>(enumerable);
        }
    }
    public class DisposableEnumerable<T> : IDisposable where T : IDisposable {
        public IEnumerable<T> Enumerable { get; }
        public DisposableEnumerable(IEnumerable<T> enumerable) {
            this.Enumerable = enumerable;
        }
        public void Dispose() {
            foreach (var o in this.Enumerable) o.Dispose();
        }
    }
