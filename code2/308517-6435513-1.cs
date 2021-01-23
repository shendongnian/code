    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using System.ServiceModel.Channels;
    namespace ClientInfoSample
    {
        public class MyService : IService
        {
            public string GetData(string value)
            {
                OperationContext context = OperationContext.Current;
                MessageProperties messageProperties = context.IncomingMessageProperties;
                RemoteEndpointMessageProperty endpointProperty = messageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
               return string.Format("Hello {0}! Your IP address is {1} and your port is {2}", value, endpointProperty.Address, endpointProperty.Port);
            }
        }
    }
