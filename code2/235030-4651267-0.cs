    // MyClass.cs -- include this into every project
    public partial class MyClass {
        public void functionB() { ClassB b = new ClassB(); b.doSomething(); }
    }
    // MyClass.functionA.cs -- include only into projects that have ClassA
    public partial class MyClass {
        public void functionA() { ClassA a = new ClassA(); a.doWork(); }
    }
