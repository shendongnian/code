    new WindsorContainer()
    				.AddFacility<WcfFacility>()
    				.Register(
    					Component.For<IServiceBehavior>().Instance(metadata),
    					Component.For<IServiceBehavior>().Instance(debug),
    					Component
    						.For<IService1>()
    						.ImplementedBy<Service1>()
    						.Interceptors(Castle.Core.InterceptorReference.ForType<ServiceInterceptor>()).Anywhere
    						.Named("service1")
    						.LifeStyle.Transient
    						.AsWcfService(new DefaultServiceModel().Hosted()
    							.AddEndpoints(
    								WcfEndpoint.BoundTo(new BasicHttpBinding()),
    								WcfEndpoint.BoundTo(new WSHttpBinding(SecurityMode.None)).At("ws")
    								))
    
    
    				);
    		}
