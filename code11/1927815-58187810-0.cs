c#
abstract class Foo 
{
    private readonly FooAttributeCollection attributes;
    public Foo(FooAttributeCollection attributes=null) 
    {
        if(attributes = null) {attributes = new FooAttributeCollection(this);}
        this.attributes = attributes;
    }
}
class FooAttributeCollection 
{
    public FooAttributeCollection(Foo owner) 
    {
		var ownerInBar = owner as Bar;
    }
}
class Bar : Foo 
{
    public Bar() : base() 
    {
    }
}
