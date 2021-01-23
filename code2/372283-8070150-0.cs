    public class MyClass
    {
        public static MyClass operator &(MyClass left, MyClass right)
        {
            return new MyClass();
        }
        public static MyClass operator |(MyClass left, MyClass right)
        {
            return new MyClass();
        }
        public static MyClass operator ^(MyClass left, MyClass right)
        {
            return new MyClass();
        }
    }
    
    var a = new MyClass();
    var b = new MyClass();
    var c = a & b;
    var d = a | b;
    var e = a ^ b;
    a &= b; // a = a & b;
    c |= d; // c = c & d;
    e ^= e; // e = e ^ e;
    
