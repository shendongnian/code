    public class MoqMissingBindingResolver : NinjectComponent, IMissingBindingResolver
    {
        public IEnumerable<IBinding> Resolve(Multimap<Type, IBinding> bindings, IRequest request)
        {
            if (request.Service.IsAbstract || request.Service.IsInterface)
            {
                var moqProvider = (IProvider)Activator.CreateInstance(typeof(MoqProvider<>).MakeGenericType(request.Service));
                return new IBinding[] 
                { 
                    new Binding(request.Service, new BindingConfiguration 
                    { 
                        ProviderCallback = ctx => moqProvider,
                        ScopeCallback    = Settings.DefaultScopeCallback
                    }) 
                }; 
            }
            else
            {
                return Enumerable.Empty<IBinding>();
            }
        }
    }
