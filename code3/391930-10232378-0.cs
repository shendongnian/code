        public static void RegisterSharedChannel<T>(this ContainerBuilder builder, Func<IComponentContext, ChannelFactory<T>> @delegate, 
            Action<Autofac.Builder.IRegistrationBuilder<object, Autofac.Builder.IConcreteActivatorData, Autofac.Builder.SingleRegistrationStyle>> config)
        {
            builder.Register(c => c.Resolve<Wcf.ISharedChannel<T>>().GetChannel()).ExternallyOwned();
            //would be really nice to be able to retain the fluency of the interface, but: http://stackoverflow.com/questions/8608415/fluent-configuration-of-multiple-registrations
            //this should suffice for now...
            var facreg = builder.Register(c => @delegate(c));
            var sharereg = builder.RegisterType<Wcf.SharedChannel<T>>().AsImplementedInterfaces();
            config(facreg);
            config(sharereg);
        }
