    using System;
    using Castle.Core;
    using Castle.DynamicProxy;
    using Castle.MicroKernel;
    using Castle.MicroKernel.ModelBuilder;
    using Castle.MicroKernel.ModelBuilder.Descriptors;
    
    ...
    
    public class InterceptorSelectorContributor : IContributeComponentModelConstruction
    {
        private readonly Predicate<ComponentModel> predicate;
        private readonly IComponentModelDescriptor interceptorSelectorDescriptor;
        public InterceptorSelectorContributor(Predicate<ComponentModel> predicate, IInterceptorSelector selector)
        {
            this.predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
            var selectorRef = new InstanceReference<IInterceptorSelector>(selector);
            interceptorSelectorDescriptor = new InterceptorSelectorDescriptor(selectorRef);
        }
        public void ProcessModel(IKernel kernel, ComponentModel model)
        {
            if (predicate.Invoke(model))
            {
                interceptorSelectorDescriptor.BuildComponentModel(kernel, model);
                interceptorSelectorDescriptor.ConfigureComponentModel(kernel, model);
            }
        }
    }
