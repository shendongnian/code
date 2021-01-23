        public class MyProvider :  IProvider
        {
            public object Create(IContext context)
            {
                return new Dictionary<string, IMyInterface>{
                   {"alpha", context.Kernel.Get<ImpClassOne>()},
                   {"beta", context.Kernel.Get<ImplClassTwo>()}
                }
            }
            public Type Type
            {
                get { return typeof(IDictionary<string, IMyInterface>); }
            }
        } 
