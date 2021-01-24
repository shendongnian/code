    public class MyVoid { }
    
    public class ErrorWrapper<T> {
        public T Result;
        public bool ValidResult;
        public Exception Exception;
    
        public ErrorWrapper(T res) {
            ValidResult = true;
            Result = res;
        }
    
        public ErrorWrapper(Exception e) {
            Exception = e;
            ValidResult = false;
        }
    
        public ErrorWrapper() { //  void
            ValidResult = true;
        }
    }
    
    public class MyClass {
        public static ErrorWrapper<MyVoid> Method1(string s1, string s2) => Wrapper<MyVoid>((Action<string, string>)System.Method1, s1, s2);
        public static ErrorWrapper<string> Method2(string s) => Wrapper<string>((Func<string, string>)System.Method2, s);
        public static ErrorWrapper<MyOtherClass> Method3(string s, int i) => Wrapper<MyOtherClass>((Func<string, int, MyOtherClass>)System.Method3, s, i);
    
        private static ErrorWrapper<T> Wrapper<T>(Delegate f, params object[] p) {
            try {
                switch (default(T)) {
                    case MyVoid _:
                        f.DynamicInvoke(p);
                        return new ErrorWrapper<T>();
                    default:
                        return new ErrorWrapper<T>((T)f.DynamicInvoke(p));
                }
            }
            catch (Exception e) {
                // Handle exceptions
                return new ErrorWrapper<T>(e);
            }
        }
    }
    
    public static class ErrorWrapper {
        public static ErrorWrapper<T> New<T>(T res) => new ErrorWrapper<T>(res);
    }
    
    public class MyTypeSafeClass {
        public static ErrorWrapper<MyVoid> Method1(string s1, string s2) => WrapperAction(System.Method1, s1, s2);
        public static ErrorWrapper<string> Method2(string s) => WrapperFunc(System.Method2, s);
        public static ErrorWrapper<MyOtherClass> Method3(string s, int i) => WrapperFunc(System.Method3, s, i);
    
        private static ErrorWrapper<MyVoid> WrapperAction<T1, T2>(Action<T1, T2> f, T1 p1, T2 p2) {
            try {
                f(p1, p2);
                return ErrorWrapper.New(default(MyVoid));
            }
            catch (Exception e) {
                // Handle exceptions
                return new ErrorWrapper<MyVoid>(e);
            }
        }
    
        private static ErrorWrapper<TRes> WrapperFunc<T1, TRes>(Func<T1, TRes> f, T1 p1) {
            try {
                return ErrorWrapper.New(f(p1));
            }
            catch (Exception e) {
                // Handle exceptions
                return new ErrorWrapper<TRes>(e);
            }
        }
    
        private static ErrorWrapper<TRes> WrapperFunc<T1, T2, TRes>(Func<T1, T2, TRes> f, T1 p1, T2 p2) {
            try {
                return ErrorWrapper.New(f(p1, p2));
            }
            catch (Exception e) {
                // Handle exceptions
                return new ErrorWrapper<TRes>(e);
            }
        }
    }
