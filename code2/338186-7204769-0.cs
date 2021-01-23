    using System;
    using System.ServiceModel.Description;
    using Castle.Facilities.WcfIntegration;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.Windsor.Installer;
 
    
    namespace Riverdale.Web
    {
        public class Global : System.Web.HttpApplication
        {
            private static IWindsorContainer _container;
            protected void Application_Start(object sender, EventArgs e)
            {
                var returnFaults = new ServiceDebugBehavior
                                       {
                                           IncludeExceptionDetailInFaults = true,
                                           HttpHelpPageEnabled = true
                                       };
    
                var metadata = new ServiceMetadataBehavior { HttpGetEnabled = true };
    
                InversionOfControl.RegisterAll();
                InversionOfControl.Container
                    .AddFacility<WcfFacility>()
                    .Install(Configuration.FromXmlFile("SearchCustomerWindsorConfig.xml"))
                    .Register(
                        Component.For<IServiceBehavior>().Instance(returnFaults),
                        Component.For<IServiceBehavior>().Instance(metadata));
                _container = InversionOfControl.Container;
            }
    
            protected void Application_End(object sender, EventArgs e)
            {
                if (_container != null)
                {
                    _container.Dispose();
                }
            }
        }
    }
