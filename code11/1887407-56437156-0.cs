C#
internal interface IDataHelper<T>
{
    int Insert(T aType);
}
internal class ProductDataHelper : IDataHelper<Product>
{
    public int Insert(Product aType)
    {  
        // ...
    }
}
**n.b.** contrary to what the comment in your question suggests, explicit implementations of an interface methods are also ``public`` even though the ``public`` key word is not present.
