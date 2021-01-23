void Main()
{
    MainServer();
}
// Client
void MainClient()
{
    ChannelFactory<IService> cf = new ChannelFactory<IService>(new WebHttpBinding(), "http://localhost:8000");
    cf.Endpoint.Behaviors.Add(new WebHttpBehavior());
    IService channel = cf.CreateChannel();
    Console.WriteLine(channel.GetMessage("Get"));
    Console.WriteLine(channel.PostMessage("Post"));
    Console.Read();
}
// Service
void MainService()
{
    WebServiceHost host = new WebServiceHost(typeof(Service), new Uri("http://localhost:8080"));
    ServiceEndpoint ep = host.AddServiceEndpoint(typeof(IService),new WebHttpBinding(), "");
    ServiceDebugBehavior stp = host.Description.Behaviors.Find<ServiceDebugBehavior>();
    stp.HttpHelpPageEnabled = false;
    stp.IncludeExceptionDetailInFaults = true;
    host.Open();
    Console.WriteLine("Service is up and running");
    Console.ReadLine();
    host.Close();    
}
// IService.cs
[ServiceContract]
public interface IService
{
    [OperationContract]
    [WebInvoke(Method="GET", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    string GetMessage(string inputMessage);
    
    [OperationContract]
    [WebInvoke(Method="POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    string PostMessage(string inputMessage);
    
    [OperationContract]
    [WebInvoke(Method="POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
    System.IO.Stream PostJson(System.IO.Stream json);
}
// Service.cs
public class Service : IService
{
    public string GetMessage(string inputMessage){
        Console.WriteLine(inputMessage);
        return "Calling Get for you " + inputMessage;
    }
    public string PostMessage(string inputMessage){
        Console.WriteLine(inputMessage);
        return "Calling Post for you " + inputMessage;
    }
    public System.IO.Stream PostJson (System.IO.Stream json) {
        Console.WriteLine(new System.IO.StreamReader(json).ReadToEnd());
        return json;
    }
}
