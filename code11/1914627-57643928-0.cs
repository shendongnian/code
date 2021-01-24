    public interface ICookieContainerAccessor {
        CookieContainer CookieContainer { get; }
    }
    public class DefaultCookieContainerAccessor : ICookieContainerAccessor {
        private static Lazy<CookieContainer> container = new Lazy<CookieContainer>();
        public CookieContainer CookieContainer => container.Value;
    }
