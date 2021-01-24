var request = RequestFactory.Create(FormParams.CopyBook);
request.Form = new Book();
If the underlying type of `request` was `Request<CopyBook>`, then its `Form` property would have the type of `CopyBook`, and trying to set its value to a `Book` wouldn't make sense.
If you determine that the above use-case should never happen, you _can_ formalize that fact by using an `interface` that doesn't allow the `Form` property to be set. Then you can make that interface [_covariant_](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/covariance-contravariance/variance-in-generic-interfaces).
public class Request<T> : IRequest<T>
    where T : Form
{
    public T Form { get; set; }
}
public interface IRequest<out T> where T : Form
{
    T Form { get; }
}
...
    public static IRequest<Form> Create(FormParams formParams)
But in that case you may find there's no reason to have `IRequest` be generic at all.
public class Request<T> : IRequest
    where T : Form
{
    public T Form { get; set; }
    Form IRequest.Form => this.Form;
}
public interface IRequest
{
    Form Form { get; }
}
...
    public static IRequest Create(FormParams formParams)
