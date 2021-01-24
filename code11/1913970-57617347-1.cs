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
        public static ErrorWrapper<MyVoid> Method1(string s1, string s2) => Wrapper<MyVoid>((Action<string,string>)System.Method1, s1, s2);
        public static ErrorWrapper<string> Method2(string s) => Wrapper<string>((Func<string,string>)System.Method2, s);
        public static ErrorWrapper<MyOtherClass> Method3(string s, int i) => Wrapper<MyOtherClass>((Func<string,string,MyOtherClass>)System.Method3, s, i);
    
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
