public class Foo
{
    public int Id { get; set; }
    public string Description { get; set; }
}
Then any plugins that want to extend this type would use an interface like so:
public interface IFooPlugin
{
   int BarId { get; set; }
   Bar Bar { get; set; }
}
You then need some way of linking IFooPlugin to Foo. If you do that, you can create a runtime type that inherits from Foo and implements IFooPlugin. You'd want to do interfaces for the plugins so you have implement multiple plugins in the type you're creating.
Your final dynamic type would look something like this:
public class DynamicFoo : IFooPlugin
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int BarId { get; set; }
    public Bar Bar { get; set; }
}
**Querying the dynamic types**
In your controllers, you won't be able to use any class to query because you need the covariance you can get from interfaces. If you cast a `DbSet<DynamicFoo>` to `IQueryable<Foo>` it will be perfectly happy to generate sql that uses any of the properties on DynamicFoo. If you tried to do the same on a `DbSet<Foo>` you'd have problems.
So essentially you'll probably want an IDbContext that has a bunch of `IRepository<T>`, where `IRepository<T>` would essentially be a wrapper around DbSet.
**Adding dynamic data**
Now the last hard part is to actually add the dynamic data to your Sql projection. Instead of doing 'Select', create a new extension method called 'SelectAndExtend' or something. This is where we will find all the extra expressions to add. 
You'll need some kind of interface defined that returns an `Expression<Func<TSource, TResult>>`. TSource can be `Foo` or `IFooPlugin`, or any type that is implemented by your final dynamic DbSet type. TResult can literally be any class.
For each of these `Expression<Func<TSource, TResult>>`'s, you'll want to get all the properties that they 'select into'. Using this, you will want to create yet another runtime type with all these properties. This becomes your DTO for the dynamic properties.
You can then build up a new expression using the ExpressionVisitor and copying all the expressions across. Originally I made the IQueryable actually return a new runtime type that has all the required properties, but this causes issues if you do an async method because Task's.
Instead, I added an extra property to the original DTO called 'ExtensionProperties' that is just an object. I can then select the dynamic DTO I generated straight into this new 'ExtensionProperties' property. 
The Result
-
In the end this does actually work, but there are A LOT of problems with doing something like this. I was able to get it to generate a single Sql statement that uses properties on a type that is defined at run time. I could then add/remove Dll's to change the object that gets returned from the server.
I've trivialized a bunch of stuff and skipped over some other issues with it, but basically it isn't really something that'd be worth doing. Keep in mind, this only deals with querying plugin data, actually being able to commit the plugin data would be a completely different beast.
I never actually completed it fully because I satisfied my curiosity about whether it was possible, and also got far enough to realise it wasn't going to be something I'd want to use going forwards.
If anyone has any questions, let me know.
