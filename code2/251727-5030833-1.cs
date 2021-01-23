    public interface IMyClass
    {
    }
    public class MyClassA : IMyClass
    {
    }
    public class MyClassB : IMyClass
    {
    }
    public class MyClassC : IMyClass
    {
    }
    static void Main(string[] args)
    {
        var listA = new List<IMyClass>{new MyClassA{}, new MyClassA{}};
        var listB = new List<IMyClass> { new MyClassB { }, new MyClassB { } };
        var listC = new List<IMyClass> { new MyClassC { }, new MyClassC { } };
        List<IMyClass> genericList = listA.Cast<IMyClass>().ToList();
    }
Something like this will compile properly and also allow you to assign different lists of any types that implement the common interface, to the same variable (in this case genericList.
