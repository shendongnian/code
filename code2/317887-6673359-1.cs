    class NamedParameterResolutionModule<TService> : Module
    {
        Parameter _attachedParameter = new ResolvedParameter(
            (pi, c) => pi.ParameterType == typeof(TService),
            (pi, c) => c.ResolveNamed<TService>(pi.Name));
        protected override void AttachToComponentRegistration(
            IComponentRegistry registry,
            IComponentRegistration registration)
        {
            registration.Preparing += (s, e) => {
                e.Parameters = new[] { _attachedParameter }.Contact(e.Parameters);
            };
        }
    }
