    using System;
    using System.Diagnostics;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using Microsoft.SharePoint.Client.Services;
    
    namespace MyNamespace
    {
        public class MyFactory : MultipleBaseAddressBasicHttpBindingServiceHostFactory
        {
            protected override ServiceHost CreateServiceHost(Type serviceType,
                Uri[] baseAddresses)
            {            
                ServiceHost host = new MultipleBaseAddressBasicHttpBindingServiceHost(
                    serviceType, baseAddresses);
    
                if (host != null)
                {
                    host.Opening += new EventHandler(OnHost_Opening);
                }
    
                return host;
            }
    
            private void OnHost_Opening(object sender, EventArgs e)
            {
                Debug.Assert(sender != null);
                ServiceHost host = sender as ServiceHost;
                Debug.Assert(host != null);
    
                // Configure the binding values
                if (host.Description != null && host.Description.Endpoints != null)
                {
                    foreach (var endPoint in host.Description.Endpoints)
                    {                    
                        if (endPoint != null && endPoint.Binding != null)
                        {
                            BasicHttpBinding basicBinding = endPoint.Binding
                                as BasicHttpBinding;
    
                            if (basicBinding != null)
                            {
                                ConfigureBasicHttpBinding(basicBinding);
                            }
                        }
                    }
                }
            }
    
            private static void ConfigureBasicHttpBinding(BasicHttpBinding basicBinding)
            {
                Debug.Assert(basicBinding != null);
                basicBinding.MaxReceivedMessageSize = Int32.MaxValue;
                basicBinding.ReaderQuotas.MaxArrayLength = Int32.MaxValue;
                basicBinding.ReaderQuotas.MaxBytesPerRead = Int32.MaxValue;
                basicBinding.ReaderQuotas.MaxStringContentLength = Int32.MaxValue;
            }
        }
    }
    As you can see I’m setting maximum length of the incoming messages.
    
    Now we need to modify our service svc file to use our custom Factory Configuration:
    <%@ ServiceHost Language="C#" Debug="true"
        Service="MyNamespace.MyService, $SharePoint.Project.AssemblyFullName$"  
        CodeBehind="MyService.svc.cs"
        Factory="MyNamespace.MyFactory, $SharePoint.Project.AssemblyFullName$"%>
