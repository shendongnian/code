    void Main()
    {
        Console.WriteLine(typeof(MyClass).GetMethod("ToString").DeclaringType != typeof(object));
        Console.WriteLine(typeof(MyOtherClass).GetMethod("ToString").DeclaringType != typeof(object));
    }
    
    class MyClass 
    {
        public override string ToString() { return ""; }
    }
    
    class MyOtherClass {
    }
