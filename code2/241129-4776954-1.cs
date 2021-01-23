    class ExposeRequestorTypeModule : Autofac.Module
    {
        Parameter _exposeRequestorTypeParameter = new ResolvedParameter(
           (pi, c) => c.IsRegistered(pi.ParameterType),
           (pi, c) => c.Resolve(
               pi.ParameterType,
               TypedParameter.From(pi.DeclaringType)));
        protected override void AttachToComponentRegistration(
                IComponentRegistry registry,
                IComponentRegistration registration)
        {
            registration.Preparing += (s, e) => {
                e.Parameters = new[] { _exposeRequestorTypeParameter }
                    .Concat(e.Parameters);
            };
        }
    }
