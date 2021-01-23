    public delegate bool DoSomething(string withWhat);
    
    class MyClass {
        private event DoSomething MyEvent;
    }
