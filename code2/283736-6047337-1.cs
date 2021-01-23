    public class ProxyTypeObject : ObservableObject
    {
        private string whoCaresItsBroke;
        // step 1:
        // make the property virtual, otherwise it will not be overridden by the proxy
        public virtual string WhoCaresItsBroke
        {
          // original implementation
        }
        public void PublicRaisePropertyChanged(string name)
        {
            RaisePropertyChanged(name);
        }
    }
    public static class AopProxyFactory
    {
        public static object GetProxy(object target)
        {
            ProxyFactory factory = GetFactory(target);
            
            object proxy = factory.GetProxy();
            if(target is ProxyTypeObject)
            {
                // step 2:
                // hack: hook handlers ...
                var targetAsProxyTypeObject = (ProxyTypeObject)target;
                var proxyAsProxyTypeObject = (ProxyTypeObject)proxy;
                HookHandlers(targetAsProxyTypeObject, proxyAsProxyTypeObject);
            }
            return proxy;
        }
        private static void HookHandlers(ProxyTypeObject target, ProxyTypeObject proxy)
        {
            target.PropertyChanged += (sender, e) =>
            {
                proxy.PublicRaisePropertyChanged(e.PropertyName);
            };
        }
        private static ProxyFactory GetFactory(object target)
        {
            var factory = new ProxyFactory(target);
            // I simply add the advice here, but you could useyour original
            //  factory.AddAdvisor( ... )
            factory.AddAdvice(new UnitValidationBeforeAdvice());
            // You don't need this:
            // factory.AddAdvice(new NotifyPropertyChangedAdvice()); 
            factory.ProxyTargetType = true;
            return factory;
        }
    }
