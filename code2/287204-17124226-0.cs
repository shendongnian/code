    class Foo
    {
    
    public string ElementName {get; set;}
    
    
    }
    
    public class MyParent
    {
    Foo _bar =new Foo();
    
    public MyParent()
    {
    //You can find Foo(s) here and then set ElementName of Each foo by reflection
    }
    }
