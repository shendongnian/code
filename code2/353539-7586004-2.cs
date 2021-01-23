    using System;
    using System.ServiceModel;
    
    namespace Utility
    {
        public class ServiceHelper
        {
    
            /// <summary>
            /// WCF proxys do not clean up properly if they throw an exception. This method ensures that the service 
            /// proxy is handeled correctly. Do not call TService.Close() or TService.Abort() within the action lambda.
            /// </summary>
            /// <typeparam name="TService">The type of the service to use</typeparam>
            /// <param name="action">Lambda of the action to performwith the service</param>
            [System.Diagnostics.DebuggerStepThrough]
            public static void UsingProxy<TService>(Action<TService> action)
                where TService : ICommunicationObject, IDisposable, new()
            {
                var service = new TService();
                bool success = false;
                try
                {
                    action(service);
                    if (service.State != CommunicationState.Faulted)
                    {
                        service.Close();
                        success = true;
                    }
                }
                finally
                {
                    if (!success)
                    {
                        service.Abort();
                    }
                }
            }
            /// <summary>
            /// WCF proxys do not clean up properly if they throw an exception. This method ensures that the service 
            /// proxy is handeled correctly. Do not call TService.Close() or TService.Abort() within the action lambda.
            /// </summary>
            /// <typeparam name="TIServiceContract">The type of the service contract to use</typeparam>
            /// <param name="action">Action to perform with the client instance.</param>
            /// <remarks>In the configuration, an endpoint with names that maches the <typeparamref name="TIServiceContract"/> name
            /// must exists. Otherwise, use <see cref="UsingContract&lt;TIServiceContract&gt;(string endpointName, Action<TIServiceContract> action)"/>. </remarks>
            [System.Diagnostics.DebuggerStepThrough]
            public static void UsingContract<TIServiceContract>(Action<TIServiceContract> action)
            {
                UsingContract<TIServiceContract>(
                    typeof(TIServiceContract).Name,
                    action
                    );
            }
            /// <summary>
            /// WCF proxys do not clean up properly if they throw an exception. This method ensures that the service 
            /// proxy is handeled correctly. Do not call TService.Close() or TService.Abort() within the action lambda.
            /// </summary>
            /// <typeparam name="TIServiceContract">The type of the service contract to use</typeparam>
            /// <param name="action">Action to perform with the client instance.</param>
            /// <param name="endpointName">Name of the endpoint to use</param>
            [System.Diagnostics.DebuggerStepThrough]
            public static void UsingContract<TIServiceContract>(
                  string endpointName,
                  Action<TIServiceContract> action)
            {
                var cf = new ChannelFactory<TIServiceContract>(endpointName);
                var channel = cf.CreateChannel();
                var clientChannel = (IClientChannel)channel;
    
                bool success = false;
                try
                {
                    action(channel);
                    if (clientChannel.State != CommunicationState.Faulted)
                    {
                        clientChannel.Close();
                        success = true;
                    }
                }
                finally
                {
                    if (!success) clientChannel.Abort();
                }
            }
        }    
    }
