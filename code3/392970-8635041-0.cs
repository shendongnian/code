    public class MyClass
    {
      public List<Student> Students { get; set;}
    }
    var aClass = new MyClass{ Students = new List<Student>
                                         { new Student(), new Student()//... }}
