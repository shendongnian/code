        /// <summary>
        /// Indicates that the service should be bound to the specified constant value.
        /// </summary>
        /// <param name="value">The constant value.</param>
        public IBindingWhenInNamedWithOrOnSyntax<T> ToConstant(T value)
        {
            Binding.ProviderCallback = ctx => new ConstantProvider<T>(value);
            Binding.Target = BindingTarget.Constant;
            Binding.ScopeCallback = StandardScopeCallbacks.Singleton;
            return this;
        }
