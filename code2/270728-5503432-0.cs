    namespace Foo
    {
       public class Orange{}
       public static explicit operator Foo.Orange(Bar.Orange) { // conversion code }
    
    }
    namespace Bar
    {
       public class Orange{}
       public static explicit operator Bar.Orange(Foo.Orange) { // conversion code }
    }
    
    // somewhere else
    Foo.Orange o = new Foo.Orange();
    Bar.Orange bar = (Bar.Orange)o; // and vice-versa
