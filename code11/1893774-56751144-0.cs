    public class LoggingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Log4NetLogFactory>().As<ILogFactory>().SingleInstance();
            builder.Register((c, p) => c.Resolve<ILogFactory>().GetLogger(p.TypedAs<Type>()));
        }
        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            registration.Preparing +=
                (sender, args) =>
                {
                    var forType = args.Component.Activator.LimitType;
                    var logParameter = new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof(ILog),
                        (p, c) => c.Resolve<ILog>(TypedParameter.From(forType)));
                    args.Parameters = args.Parameters.Union(new[] { logParameter });
                };
        }
    }
