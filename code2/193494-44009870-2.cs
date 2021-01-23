    public class Monad {
        private Monad() { Success = true; }
        private Monad(Exception ex) {
            IsExceptionState = true;
            Exception = ex;
        }
        public static Monad Success() => new Monad();
        public static Monad Failure(Exception ex) => new Monad(ex);
        public bool Success { get; private set; }
        public bool IsExceptionState { get; private set; }
        public Exception Exception { get; private set; }
    }
