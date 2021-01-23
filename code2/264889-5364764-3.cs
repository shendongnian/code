    public class TestClientBehaviorExtensionElement:UnityBehaviorExtensionElement
    {
        protected override Func<Type, string, UnityInstanceProvider> InstanceProviderFunc()
        {
            return (type, str) => new UnityInstanceProvider(type, str, CreateUnityContainer);
        }
    
        ///<summary>
        ///</summary>
        ///<param name="containerName"></param>
        ///<returns></returns>
        public IUnityContainer CreateUnityContainer(string containerName)
        {
            IUnityContainer unityContainer = new UnityContainer();
            try
            {
                unityContainer.RegisterType<IOperationContextService, OperationContextService>(new UnityOperationContextLifetimeManager());
              ...
            }
            catch (Exception)
            {
                unityContainer.Dispose();
                throw;
            }
    
            return unityContainer;
        }
