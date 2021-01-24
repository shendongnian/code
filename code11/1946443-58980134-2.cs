public class ThingTransformer
{
    public string Transform(FirstThing thing) => _firstThingTransformStrategy.Transform(thing);
    public string Transform(SecondThing thing) => _secondThingTransformStrategy.Transform(thing);
}
public interface IThing
{
    // ...
    string Transform(ThingTransformer transformer);
}
public class FirstThing : IThing
{
    // ...
    public string Transform(ThingTransformer transformer) => transformer.Transform(this);
}
public class SecondThing : IThing
{
    // ...
    public string Transform(ThingTransformer transformer) => transformer.Transform(this);
}
Then you can write:
var thing = new FirstThing();
var transformer = new ThingTransformer();
var transformed = thing.Transform(transform);
This has the advantage of compile-time safety: if you add a new implementation of `IThing`, you end up with compiler errors until you've added the new method to `ThingTransformer`.
If you want to abstract things a bit, hide `ThingTransformer` behind an interface, and make `IThing` take that interface instead of the concrete `ThingTransformer`.
---------
More generally, you can write a generic visitor:
public interface IThingVisitor<T>
{
    T Accept(FirstThing thing);
    T Accept(SecondThing thing);
}
public interface IThing
{
    T Visit<T>(IThingVisitor<T> visitor);
}
public class FirstThing : IThing
{
    public T Visit<T>(IThingVisitor<T> visitor) => visitor.Accept(this);
}
public class SecondThing : IThing
{
    public T Visit<T>(IThingVisitor<T> visitor) => visitor.Accept(this);
}
public class ThingTransformer : IThingVisitor<string>
{
    public string Accept(FirstThing thing) => _firstThingTransformStrategy.Transform(thing);
    public string Accept(SecondThing thing) => _secondThingTransformStrategy.Transform(thing);
}
Then:
var thing = new FirstThing();
var transformer = new ThingTransformer();
var transformed = thing.Visit(transformer);
