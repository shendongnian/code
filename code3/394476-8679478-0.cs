    public static class MyContainer
    {
        public static UnityContainer Container { get; set; }
    }
    class ServiceClass<T>
    {}
    class ReturnClass
    {}
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        ReturnClass DoResolve(string name)
        {
            Type type = typeof (UnityContainer);
            MethodInfo genericMethod = type.GetMethod("Resolve").MakeGenericMethod(typeof(ServiceClass<>).MakeGenericType(new Type[]{Type.GetType(name)}));
            object invoke = genericMethod.Invoke(MyContainer.Container,null);
            return (ReturnClass) invoke;
        }
    }
