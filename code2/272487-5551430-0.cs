    public interface A { string Property { get; set; } }
    public interface B { string Property { get; set; } }
    public interface C : A, B { }
    public class MyClass : C
    {
        string B.Property { get; set; }
        string A.Property { get; set; }
    }
