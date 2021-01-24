[ServiceContract]
public interface IMyService
{
    [OperationContract]
    [XmlSerializerFormat]
    void StoreSomething(StoreSomethingMessage message);
}
[MessageContract(IsWrapped=false)]
public class StoreSomethingMessage
{
    [MessageBodyMember(Namespace="urn:aaa")]
    public StoreSomething StoreSomething { get; set; }
}
[XmlType(Namespace="urn:bbb")]
public class StoreSomething
{
    public Something Something { get; set; }
}
public class Something
{
    public string SomeText { get; set; }
}
I also created a MyServiceClient which implements IMyService and inherits from ClientBase&lt;IMyService&gt; since IMyService now requires a StoreSomethingMessage object, but i left that part out for simplicity.
I wish there was a simpler solution.
[1]: https://docs.microsoft.com/en-us/dotnet/framework/wcf/samples/unwrapped-messages
