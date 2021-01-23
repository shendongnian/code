    public interface IStrings {
        string HelloWorld { get; }
    }
    public sealed class LocalStringService : IStrings {
        internal LocalStringService() { }
        string IStrings.HelloWorld {
            get { return "Hello World!"; }
        }
    }
    public static class StringService {
        private static readonly IStrings SingletonInstance = new LocalStringService();
        // If empty static constructor does not make any sense, read this:
        // http://csharpindepth.com/Articles/General/Beforefieldinit.aspx
        static StringService() { }
        public static IStrings Instance {
            get { return SingletonInstance; }
        }
    }
