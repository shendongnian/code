    public class Test
    {
        // this is not a local variable, this is a definition of field with initialization
        A a = new A();
        // you try call method on field, but in context of class definition, which is prohibited
        a.method1();
    }
