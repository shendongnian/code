    public class TargetPreparingCallbackModule<T> : Module
    {
        public TargetPreparingCallbackModule(Func<Type, Parameter> targetPreparing)
        {
            this._targetPreparing = targetPreparing;
        }
        private readonly Func<Type, Parameter> _targetPreparing;
        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry,
                IComponentRegistration registration)
        {
            registration.Preparing += this.Registration_Preparing;
        }
        private void Registration_Preparing(object sender, PreparingEventArgs e)
        {
            var t = e.Component.Activator.LimitType;
            e.Parameters = e.Parameters.Union(
                new[]
                {
                    new ResolvedParameter(
                        (p, c) => p.ParameterType == typeof (T),
                        (p, c) => {
                            Parameter parameter =  this._targetPreparing(t);
                            T instance = c.Resolve<T>(parameter);
                            return instance;
                        })
                });
        }
    }
 
