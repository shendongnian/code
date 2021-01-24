    public class CustomInterception : IInterceptorPolicy
    {
        public string Description => "test interception Console.WriteLine each method' arguments and return value"; 
    
        public IEnumerable<IInterceptor> DetermineInterceptors(Type pluginType, StructureMap.Pipeline.Instance instance)
        {
            Type dispatchProxyType = DummyDispatchProxyDontUseAtWork.GenerateStructureMapCompatibleDispatchProxyType(pluginType);
                
            yield return new DecoratorInterceptor(pluginType, dispatchProxyType);
        }
    }
