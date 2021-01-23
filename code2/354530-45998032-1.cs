    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace MyNamespace
    {
        public class ThreadsafeFooModifier : 
        {
            private readonly object _lockObject;
    
            public async Task<FooResponse> ModifyFooAsync()
            {
                FooResponse result;
                Monitor.Enter(_lockObject);
                try
                {
                    result = await SomeFunctionToModifyFooAsync();
                }
                finally
                {
                    Monitor.Exit(_lockObject);
                }
                return result;
            }
    	}
    }
