    class Foo 
    {
         public void M() { Console.WriteLine("Foo"); }
    }
    
    class Bar : Foo
    {
         public new void M() { Console.WriteLine("Bar"); }
    }
    
    Bar bar = new Bar(); 
    bar.M(); // writes Bar
    Foo foo = new Bar(); // still an instance of Bar
    foo.M(); // writes Foo, does not use "new" method defined in Bar
