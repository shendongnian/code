    public abstract class AbstractClass
    {
        public abstract void Execute(IDictionary<string, object> parameters);
    }
    public class A : AbstractClass
    {
        public override void Execute(IDictionary<string, object> parameters)
        {
            int i = 0;
        }
    }
    public class MyClass : A
    {
        public override void Execute(IDictionary<string, object> parameters)
        {
            int i = 0;
            Console.WriteLine(i);
        }
    }
    public class Tests
    {
        [Fact]
        public void TestAbstractClass()
        {
            var myClass = new Mock<MyClass>() {CallBase = true};
                
            myClass.Object.Execute(new Dictionary<string, object>());
        }
    }
