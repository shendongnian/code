    using System;
    
    public abstract class Dispatcher<T> {
        public T Call(object foo)
        {
            return CallDispatch(((object)(dynamic)foo).ToString());
        }
    
        protected abstract T CallDispatch(int foo);
        protected abstract T CallDispatch(string foo);
    }
    
    public class Program {
        public static void Main() {
            TypeFinder d = new TypeFinder();
    
            Console.WriteLine(d.Call(0));
            Console.WriteLine(d.Call(""));
        }
    
        private class TypeFinder : Dispatcher<CallType> {
            protected override CallType CallDispatch(int foo) {
                return CallType.Int;
            }
    
            protected override CallType CallDispatch(string foo) {
                return CallType.String;
            }
        }
    
        private enum CallType { Int, String }
    }
