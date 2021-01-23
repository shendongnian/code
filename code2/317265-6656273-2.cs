    namespace Ninject.Web
    {
        public class HttpModuleBase : IHttpModule
        {
            /// <summary>
            /// This method is unused by the base class.
            /// </summary>
            public virtual void Dispose()
            {
                
            }
    
            /// <summary>
            /// Ininitialize the module and request injection.
            /// </summary>
            /// <param name="context"></param>
            public virtual void Init(HttpApplication context)
            {
                RequestActivation();
            }
    
            /// <summary>
            /// Asks the kernel to inject this instance.
            /// </summary>
            protected virtual void RequestActivation()
            {
                KernelContainer.Inject(this);
            }
        }
    }
