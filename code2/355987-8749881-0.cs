     /// <summary>
     /// A generic webservice client that uses BasicHttpBinding
     /// </summary>
     /// <remarks>Adopted from: http://blog.bodurov.com/Create-a-WCF-Client-for-ASMX-Web-Service-Without-Using-Web-Proxy/
     /// </remarks>
     /// <typeparam name="T"></typeparam>
     public class WebServiceClient<T> : IDisposable
     {
         private readonly T channel;
         private readonly IClientChannel clientChannel;
    
         /// <summary>
         /// Use action to change some of the connection properties before creating the channel
         /// </summary>
         public WebServiceClient(string endpointUrl, string bindingConfigurationName)
         {
             BasicHttpBinding binding = new BasicHttpBinding(bindingConfigurationName);
    
             EndpointAddress address = new EndpointAddress(endpointUrl);
             ChannelFactory<T> factory = new ChannelFactory<T>(binding, address);
    
             this.clientChannel = (IClientChannel)factory.CreateChannel();
             this.channel = (T)this.clientChannel;
         }
    
         /// <summary>
         /// Use this property to call service methods
         /// </summary>
         public T Channel
         {
             get { return this.channel; }
         }
    
         /// <summary>
         /// Use this porperty when working with Session or Cookies
         /// </summary>
         public IClientChannel ClientChannel
         {
             get { return this.clientChannel; }
         }
    
         public void Dispose()
         {
             this.clientChannel.Dispose();
         }
     }
