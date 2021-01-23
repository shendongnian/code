    using System;
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using StructureMap;
    using StructureMap.Pipeline;
    using System.Linq;
    
    using ServiceHostCreator = System.Func<System.Type, System.Uri[], System.ServiceModel.ServiceHost>;
    
    namespace x.ServiceExtensions
    {
        public class xWebServiceHostFactory : ServiceHostFactory
        {
            private readonly IDictionary<InstanceContextMode, ServiceHostCreator> _serviceHostCreators;
    
            public xWebServiceHostFactory()
            {
                ObjectFactory.Initialize( init =>
                                          init.Scan( scan =>
                                                         {
                                                             scan.AssembliesFromApplicationBaseDirectory();
                                                             scan.IgnoreStructureMapAttributes();
                                                             scan.LookForRegistries();
                                                         } ) );
                _serviceHostCreators = new Dictionary<InstanceContextMode, ServiceHostCreator>
                                            {
                                                { InstanceContextMode.PerCall, ( t, a ) => PerCallServiceHostCreator( t, a ) },
                                                { InstanceContextMode.PerSession, ( t, a ) => PerSessionServiceHostCreator( t, a ) },
                                                { InstanceContextMode.Single, ( t, a ) => SingleInstanceServiceHostCreator( t, a ) }
                                            };
            }
    
            protected override ServiceHost CreateServiceHost( Type serviceType, Uri[] baseAddresses )
            {
                var serviceInstanceContextMode = GetServiceInstanceContextMode( serviceType );
                var serviceHostCreator = _serviceHostCreators[ serviceInstanceContextMode ];
                return serviceHostCreator( serviceType, baseAddresses );
            }
    
            private static InstanceContextMode GetServiceInstanceContextMode( Type serviceType )
            {
                var serviceBehaviour = serviceType
                    .GetCustomAttributes( typeof ( ServiceBehaviorAttribute ), true )
                    .Cast<ServiceBehaviorAttribute>()
                    .SingleOrDefault();
                return serviceBehaviour.InstanceContextMode;
            }
    
            private static ServiceHost PerCallServiceHostCreator( Type serviceType, Uri[] baseAddresses )
            {
                var args = new ExplicitArguments();
                args.Set( serviceType );
                args.Set( baseAddresses );
                var serviceHost = ObjectFactory.GetInstance<TelaWebServiceHost>( args );
                return serviceHost;
            }
    
            private static ServiceHost PerSessionServiceHostCreator( Type serviceType, Uri[] baseAddresses )
            {
                return PerCallServiceHostCreator( serviceType, baseAddresses );
            }
    
            private static ServiceHost SingleInstanceServiceHostCreator( Type serviceType, Uri[] baseAddresses )
            {
                var service = ObjectFactory.GetInstance( serviceType );
                var args = new ExplicitArguments();
                args.Set( typeof(object), service );
                args.Set( baseAddresses );
                var serviceHost = ObjectFactory.GetInstance<TelaWebServiceHost>( args );
                return serviceHost;
            }
        }
    }
