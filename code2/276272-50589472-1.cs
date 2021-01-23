    using System;
    
    using Castle.Core;
    using Castle.MicroKernel;
    using Castle.MicroKernel.ModelBuilder;
    using Castle.MicroKernel.ModelBuilder.Descriptors;
    
    ...
    
    public class InterceptorsContributor : IContributeComponentModelConstruction
    {
        private readonly Predicate<ComponentModel> predicate;
        private readonly IComponentModelDescriptor interceptorsDescriptor;
    
        public InterceptorsContributor(Predicate<ComponentModel> predicate, params InterceptorReference[] interceptors)
        {
            this.predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
            interceptorsDescriptor = new InterceptorDescriptor(interceptors);
        }
    
        public void ProcessModel(IKernel kernel, ComponentModel model)
        {
            if (predicate.Invoke(model))
            {
                interceptorsDescriptor.BuildComponentModel(kernel, model);
                interceptorsDescriptor.ConfigureComponentModel(kernel, model);
            }
        }
    }
