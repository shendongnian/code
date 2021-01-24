public class messageProcessor
{
    private readonly IElementFactory elementFactory;
    public messageProcessor(IElementFactory elementFactory)
    {
        this.elementFactory = elementFactory;
    }
    public string Process(string settings)
    {
        var strategyToUse = new legacyStrategy();
        ...
        var resources = new messageResource(
           this.elementFactory,
           strategyToUse,
           ...);
    }
}
Now, in your test, you can inject a substitute of the `IElementFactory`. Like this:
public void Test()
{
    var elementFactory = Substitute.For<IElementFactory>();
  
    // tell the substitute what it should return when a specific method is called.
    elementFactory.AnyMethod().Returns(something);
       
    var processor = new messageProcessor(elementFactory);
}
At runtime your application should inject an instance of the `IElementFactory` into the `messageProcessor` class. You should do this via ["Dependency injection"][2]. 
  [1]: http://joelabrahamsson.com/inversion-of-control-an-introduction-with-examples-in-net/
  [2]: https://www.codementor.io/mrfojo/c-with-dependency-injection-k2qfxbb8q
