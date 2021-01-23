        using System;
        using System.ServiceModel;
        using System.ServiceModel.Channels;
    
    public class UserClient : ClientBase<IAsyncESPUserService> , IESPUserService
    {
            /// <summary>
            /// Constructor - No Parameters, this will use a default target endpoint.
            /// </summary>
            public UserClient() : base() { }
            
            /// <summary>
            /// Constructor - Binding and Address Parameters
            /// </summary>
            /// <param name="binding">How we are communicating.</param>
            /// <param name="address">The address we are communicating to.</param>
            public UserClient(Binding binding, EndpointAddress address) : base(binding, address) { }
    
            /// <summary>
            /// Constructor - Configuration Name Parameter
            /// </summary>
            /// <param name="endpointConfigurationName">The name of the configuration in ServiceReferences.ClientConfig. </param>
            public UserClient(string endpointConfigurationName) : base(endpointConfigurationName) { }
    
               //Implement your async service calls here       
    }
