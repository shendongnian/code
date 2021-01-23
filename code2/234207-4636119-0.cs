    public class A{}
    public class B : A {}
    
    public class X<T> where T: A {}
    public class Y<T> : X<T> where T: B { }
