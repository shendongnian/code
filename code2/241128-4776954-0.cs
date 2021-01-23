    class ExposeRequestorTypeModule : Autofac.Module
    {
        protected override void AttachToComponentRegistration(
                IComponentRegistry registry,
                IComponentRegistration registration)
        {
            registration.Preparing += (s, e) => {
                e.Parameters = new Parameter[] {
                    TypedParameter.From(registration.Activator.LimitType);
                }.Concat(e.Parameters);
            };
        }
    }
