    using System;
    using System.Collections.Specialized;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using System.ServiceModel.Web;
    
    namespace DecoupledWcfServices
    {
        /// <summary>
        /// Service 1 and Service 2 are in the same namespace in this project
        /// </summary>
        public class MessageBus
        {
            public string CallOtherWcfService(string url, object content, NameValueCollection headers)
            {
                var service = GetServiceName(url);
                    try
                {
                    var netPipeUrl = $"http://localhost:54412/{service}/{service}.svc";
                    var serviceContractType = typeof(IService2);
                    var genericChannelFactoryType = typeof(WebChannelFactory<>).MakeGenericType(serviceContractType);
                    var binding = new WebHttpBinding();
        
                    var channelFactory = Activator.CreateInstance(genericChannelFactoryType, binding, new Uri(netPipeUrl)) as WebChannelFactory<IService2>; // I actually won't know it is an IService2 in my project, but getting this far should be enough
                    var proxy = channelFactory.CreateChannel() as IService2; 
                    using (new OperationContextScope((IContextChannel)proxy))
                    {
                        var task = proxy.GetData("some data"); // Might need more work here to know which method to call based on the Url
                        task.Wait();
                        return task.Result; // Serialized JSON
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
    
            internal string GetServiceName(string url)
            {
                var index = url.IndexOf(".svc");
                var sub = url.Substring(0, index);
                index = sub.LastIndexOf("/") + 1;
                var sub2 = url.Substring(index, sub.Length - index);
                return sub2;
            }
        }
    }
