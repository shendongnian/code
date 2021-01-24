public class Foo : IEntitySubMultiLang
{
    public int Id { get; set; }
}
What would happen if you passed a `Foo` to `_r.Add()`?
_r.Add(new Foo());
This wouldn't make any sense, because `_r` is a `GenericRepo<Entry>`, and doesn't know how to add `Foo`s. That's exactly the sort of situation type safety is supposed to avoid.
### Update, based on OP Edit
Because you're using reflection to produce your objects, you're really getting no compile-time benefit from the interfaces in terms of type safety when you're calling `_r.Add()`. So embrace that fact, and use reflection to call the `Add` method, without attempting to do any casting. 
    constructedClass
        .GetMethod("Add")
        .MakeGenericMethod(className)
        .Invoke(created, new object[] { inst });
Alternatively, there is a good chance you can simplify a lot of your code, and still get a lot of type safety, by putting everything into a generic helper method, and calling *that method* by reflection. For example:
static private void AddToRepo<TEntity>() where TEntity : class, IEntitySubMultiLang, new
{
    new GenericRepo<TEntity>().Add(new TEntity());
}
    typeof(ConsoleApp1)
        .GetMethod("AddToRepo")
        .MakeGenericMethod(className)
        .Invoke(null, new object[] { /* any parameters? */});
