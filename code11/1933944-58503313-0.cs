namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Threading.Tasks;
    public static class ObjectExtender
    {
        internal static bool IsOfGenericType(this object obj, Type check, out Type? genericType)
        {
            Type actType = obj.GetType();
            while (actType != null && actType != typeof(object))
            {
                if (actType.IsGenericType && actType.GetGenericTypeDefinition() == check.GetGenericTypeDefinition())
                {
                    genericType = actType;
                    return true;
                }
                actType = actType.BaseType;
            }
            genericType = null;
            return false;
        }
    }
    public class Class1<T> : DispatchProxy
    {
        private static readonly MethodInfo AsyncEnumeration;
        private static readonly Dictionary<Type, MethodInfo> CachedAsyncEnumerationMethodInfos = new Dictionary<Type, MethodInfo>();
        private static readonly Dictionary<Type, MethodInfo> CachedGenericTaskMethodInfos = new Dictionary<Type, MethodInfo>();
        private static readonly Dictionary<Type, MethodInfo> CachedSyncEnumerationMethodInfos = new Dictionary<Type, MethodInfo>();
        private static readonly MethodInfo GenericTask;
        private static readonly MethodInfo SyncEnumeration;
        private T _decorated = default!;
        static Class1()
        {
            GenericTask = typeof(Class1<T>).GetMethod("HandleTaskGenericAsync", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            AsyncEnumeration = typeof(Class1<T>).GetMethod("Wrapper", BindingFlags.Static | BindingFlags.NonPublic           | BindingFlags.DeclaredOnly);
            SyncEnumeration = typeof(Class1<T>).GetMethod("SyncWrapper", BindingFlags.Static | BindingFlags.NonPublic        | BindingFlags.DeclaredOnly);
        }
        public static T Create(T decorated)
        {
            T proxy = Create<T, Class1<T>>();
            Class1<T> ap = proxy as Class1<T> ?? throw new ArgumentNullException(nameof(decorated));
            ap._decorated = decorated;
            return proxy;
        }
        private static Task<T2> HandleTaskGenericAsync<T1, T2>(T1 result, MethodInfo methodName) where T1 : Task<T2>
        {
            return result.ContinueWith(parent =>
                                       {
                                           Console.WriteLine($"After: {methodName}");
                                           return parent.Result;
                                       });
        }
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            try
            {
                Console.WriteLine($"Before: {targetMethod}");
                object result = targetMethod.Invoke(_decorated, args);
                if (result is Task resultTask)
                {
                    if (!resultTask.IsOfGenericType(typeof(Task<>), out Type? genericType))
                    {
                        return resultTask.ContinueWith(task =>
                                                       {
                                                           if (task.Exception != null)
                                                           {
                                                               Console.WriteLine($"{task.Exception.InnerException ?? task.Exception}, {targetMethod}");
                                                           }
                                                           else
                                                           {
                                                               Console.WriteLine($"After: {targetMethod}");
                                                           }
                                                       });
                    }
                    Debug.Assert(genericType != null, nameof(genericType) + " != null");
                    Type resultType = genericType.GetGenericArguments()[0]; // Task<> hat nur einen.
                    if (!CachedGenericTaskMethodInfos.ContainsKey(resultType))
                    {
                        CachedGenericTaskMethodInfos.Add(resultType, GenericTask.MakeGenericMethod(genericType, resultType));
                    }
                    return CachedGenericTaskMethodInfos[resultType].Invoke(null, new object[] {resultTask, targetMethod});
                }
                Type returnType = targetMethod.ReturnType;
                if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(IAsyncEnumerable<>))
                {
                    Type resultType = returnType.GetGenericArguments()[0]; //IAsyncEnumerable hat nur eines
                    if (!CachedAsyncEnumerationMethodInfos.ContainsKey(resultType))
                    {
                        CachedAsyncEnumerationMethodInfos.Add(resultType, AsyncEnumeration.MakeGenericMethod(resultType));
                    }
                    return CachedAsyncEnumerationMethodInfos[resultType].Invoke(null, new[] {result, targetMethod});
                }
                if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    Type resultType = returnType.GetGenericArguments()[0]; //IAsyncEnumerable hat nur eines
                    if (!CachedSyncEnumerationMethodInfos.ContainsKey(resultType))
                    {
                        CachedSyncEnumerationMethodInfos.Add(resultType, SyncEnumeration.MakeGenericMethod(resultType));
                    }
                    return CachedSyncEnumerationMethodInfos[resultType].Invoke(null, new[] {result, targetMethod});
                }
                Console.WriteLine($"After: {targetMethod}");
                return result;
            }
            catch (TargetInvocationException ex)
            {
                Console.WriteLine($"{ex.InnerException ?? ex}, {targetMethod}");
                throw;
            }
        }
        private static IEnumerable<T> SyncWrapper<T>(IEnumerable<T> inner, MethodInfo targetMethod)
        {
            foreach (T t in inner)
            {
                yield return t;
            }
            Console.WriteLine($"After List: {targetMethod}");
        }
        private static async IAsyncEnumerable<T> Wrapper<T>(IAsyncEnumerable<T> inner, MethodInfo targetMethod)
        {
            await foreach (T t in inner)
            {
                yield return t;
            }
            Console.WriteLine($"After List: {targetMethod}");
        }
    }
}
