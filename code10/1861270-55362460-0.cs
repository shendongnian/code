public class ExceptionInterceptorBehaviour : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            var method = invocation.MethodInvocationTarget;
            var isAsync = method.GetCustomAttribute(typeof(AsyncStateMachineAttribute)) != null;
            if (isAsync && typeof(Task).IsAssignableFrom(method.ReturnType))
            {
                if (method.ReturnType.IsGenericType)
                {
                    invocation.ReturnValue = typeof(ExceptionInterceptorBehaviour)
                        .GetMethod("InterceptGenericAsync", BindingFlags.Instance | BindingFlags.NonPublic)
                        .MakeGenericMethod(method.ReturnType.GenericTypeArguments[0])
                        .Invoke(this, new object[] { invocation.ReturnValue });
                }
                else
                {
                    invocation.ReturnValue = InterceptAsync((Task)invocation.ReturnValue);
                }
            }
        }
        private async Task InterceptAsync(Task task)
        {
            await task.ConfigureAwait(false);
        }
        private async Task<T> InterceptGenericAsync<T>(Task<T> task)
        {
            try
            {
                object result = await task.ConfigureAwait(false);
                return (T)result;
            }
            catch (Exception e)
            {
                if (typeof(DTOBase).IsAssignableFrom(typeof(T)))
                {
                    var ret = Activator.CreateInstance(typeof(T));
                    (ret as DTOBase).Errors.Add(e);
                    return (T)ret;
                }
                throw e;
            }
        }
    }
The fun fact is that code was still crashing when I tried to step out of `InterceptGenericAsync` in debug, but it works just fine if I let it run, which is weird and scary.
I did not test this solution on iOS though, I'm not sure it's working.
