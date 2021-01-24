csharp
public class Caller
    {
        private readonly IFoo _foo;
        private readonly IFoo _constFoo;
        public Caller()
        {
            _foo = new Foo();   // => here is exact instance type
            _constFoo = new ConstantFoo(); // => here is exact instance type
        }
        public void DummyUsage()
        {
            string arg = "Wololo";
            Console.WriteLine(_foo.Bar(arg)); // -> here you know that you need parameterarg
            Console.WriteLine(_constFoo.Bar(arg)); // -> here you know that you do not need parameter arg
        }
Now think about this:
public class Caller
    {
        private readonly IEnumerable<IFoo> _fooServices;
        
        public Caller(IEnumerable<IFoo> fooServices)
        {
            _fooServices = fooServices;
        }
        public void DummyUsage()
        {
            string arg = "Wololo";
           foreach(IFoo fooService in _fooServices)
          {
               Console.WriteLine(fooService.Bar(arg)); //==> you do not know what type of foo it is if it require internally argument or not .. But you have to pass it to satisfy contract defined by IFoo interface
          }
        }
----------------------
Now another 
Imagine you have 2 interfaces:
csharp
interface IFoo 
{
    void Bar();
}
interface IParametrizedFoo
{
    void Bar(string parameter);
}
then you can have implementation
csharp
public class Foo : IParametrizedFoo
    {
        public string Bar(string parameter)
        {
            return string.Format("{0}Fooooooo", parameter);
        }
    }
    public class ConstantFoo : IFoo, IParametrizedFoo
    {
        public string Bar()
        {
            return "Baaaaaaar";
        }
      string  IParametrizedFoo.Bar(string parameter)
{
Bar();
}
    }
then usage
csharp
public class Caller
    {
        private readonly IParametrizedFoo _foo;
        private readonly IFoo _foo;
        public Caller(IParametrizedFoo parametrizedFoo, IFoo foo)
        {
            _parametrizedFoo= parametrizedFoo;
            _foo= foo;
        }
        public void DummyUsage()
        {
            string arg = "Wololo";
            Console.WriteLine(parametrizedFoo.Bar(arg));
            Console.WriteLine(_foo.Bar());
        }
**But still i do not think is the best design**
