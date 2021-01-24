    class Program
    {
        class BaseClass
        {
            public static void Generic<T>() where T : BaseClass
            {
                Console.WriteLine(typeof(T).Name);
            }
        }
        class FirstClass : BaseClass
        {
        }
        class SecondClass : BaseClass
        {
        }
        static void Main(string[] args)
        {
            MethodInfo method = typeof(BaseClass).GetMethod("Generic");
            
            foreach (var item in Assembly.GetExecutingAssembly().GetTypes()
                                            .Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(BaseClass))))
            {
                MethodInfo generic = method.MakeGenericMethod(item);
                generic.Invoke(null, null);
            }
        }
    }
