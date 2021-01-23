    public class MyContributor : IContributeComponentModelConstruction 
    {
        public void ProcessModel(IKernel kernel, ComponentModel model)
        {
            model.Dependencies.Add(new DependencyModel(DependencyType.Service, null, typeof(MyInterceptor), false));
            model.Interceptors.AddFirst(InterceptorReference.ForType<MyInterceptor>());
        }
    }
