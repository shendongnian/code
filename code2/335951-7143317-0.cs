       public interface IDoSomething {...}
    
       public class Outer
       {
    
            public static IDoSomething GetSomethingToDo( ... parameters ...)
            { 
                if (...) return new SomethingA();
                else return new SomethingB();
            }
    
            private class SomethingA : IDoSomething { ...}
            private class SomethingB : IDoSomething { ...}
    
        }
