    public struct Target : IServiceProvider, IProvideValueTarget
    {
        private readonly DependencyObject _targetObject;
        private readonly DependencyProperty _targetProperty;
        public Target(DependencyObject targetObject, DependencyProperty targetProperty)
        {
            _targetObject = targetObject;
            _targetProperty = targetProperty;
        }
        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(IProvideValueTarget))
                return this;
            return null;
        }
        object IProvideValueTarget.TargetObject { get { return _targetObject; } }
        object IProvideValueTarget.TargetProperty { get { return _targetProperty; } }
    }
