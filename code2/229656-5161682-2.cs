    uri = "http://localhost/RestfulService";
    
    EndpointAddress address = new EndpointAddress(uri);
    WebHttpBinding binding = new WebHttpBinding();
    WebChannelFactory<IRestfulServices> factory = new WebChannelFactory<IRestfulServices>(binding, new Uri(uri));
    IRestfulServices channel = factory.CreateChannel(address, new Uri(uri));
    channel.getData(new Person{firstName = 'John', LastName = 'Doe'});
    [ServiceContract]
    public interface IRestfulService
    {
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "Data")]
        object getData(Person name)
    }
                  
