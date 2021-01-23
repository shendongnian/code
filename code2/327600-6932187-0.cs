    public class MyClass
    {
     public MyString string { get; set; }
     public MyInt int { get; set; }
    }
    
    var list = new Collection<MyClass>
               {
                 new MyClass { MyInt = 1, MyString = "Test1" },
                 new MyClass { MyInt = 2, MyString = "Test2" }
               }
