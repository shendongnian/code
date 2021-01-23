    public static class SampleCode
    {
        public static void Main()
        {
            IList<Type> loadableTypes;
            // instance the dummy class used to find the current assembly
            DummyClass dc = new DummyClass();
            loadableTypes = GetClassesImplementingAnInterface(dc.GetType().Assembly, typeof(IMsgXX)).Item2;
            foreach (var item in loadableTypes) {Console.WriteLine("1: " + item);}
            // print
            // 1: Start2.MessageHandlerXY
            loadableTypes = GetClassesImplementingAnInterface(dc.GetType().Assembly, typeof(IHandleMessageG<>)).Item2;
            foreach (var item in loadableTypes) { Console.WriteLine("2: " + item); }
            // print
            // 2: Start2.MessageHandlerXY
            // 2: Start2.MessageHandlerZZ
        }
        ///<summary>Read all classes in an assembly that implement an interface (generic, or not generic)</summary>
        //
        // some references
        // return all types implementing an interface
        // http://stackoverflow.com/questions/26733/getting-all-types-that-implement-an-interface/12602220#12602220
        // http://haacked.com/archive/2012/07/23/get-all-types-in-an-assembly.aspx/
        // http://stackoverflow.com/questions/7889228/how-to-prevent-reflectiontypeloadexception-when-calling-assembly-gettypes
        // return all types implementing a generic interface
        // http://stackoverflow.com/questions/33694960/find-all-types-implementing-a-certain-generic-interface-with-specific-t-type
        // http://stackoverflow.com/questions/8645430/get-all-types-implementing-specific-open-generic-type
        // http://stackoverflow.com/questions/1121834/finding-out-if-a-type-implements-a-generic-interface
        // http://stackoverflow.com/questions/5849210/net-getting-all-implementations-of-a-generic-interface
        public static Tuple<bool, IList<Type>> GetClassesImplementingAnInterface(Assembly assemblyToScan, Type implementedInterface)
        {
            if (assemblyToScan == null)
                return Tuple.Create(false, (IList<Type>)null);
            if (implementedInterface == null || !implementedInterface.IsInterface)
                return Tuple.Create(false, (IList<Type>)null);
            IEnumerable<Type> typesInTheAssembly;
            try
            {
                typesInTheAssembly = assemblyToScan.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                typesInTheAssembly = e.Types.Where(t => t != null);
            }
            IList<Type> classesImplementingInterface = new List<Type>();
            // if the interface is a generic interface
            if (implementedInterface.IsGenericType)
            {
                foreach (var typeInTheAssembly in typesInTheAssembly)
                {
                    if (typeInTheAssembly.IsClass)
                    {
                        var typeInterfaces = typeInTheAssembly.GetInterfaces();
                        foreach (var typeInterface in typeInterfaces)
                        {
                            if (typeInterface.IsGenericType)
                            {
                                var typeGenericInterface = typeInterface.GetGenericTypeDefinition();
                                var implementedGenericInterface = implementedInterface.GetGenericTypeDefinition();
                                if (typeGenericInterface == implementedGenericInterface)
                                {
                                    classesImplementingInterface.Add(typeInTheAssembly);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (var typeInTheAssembly in typesInTheAssembly)
                {
                    if (typeInTheAssembly.IsClass)
                    {
                        // if the interface is a non-generic interface
                        if (implementedInterface.IsAssignableFrom(typeInTheAssembly))
                        {
                            classesImplementingInterface.Add(typeInTheAssembly);
                        }
                    }
                }
            }
            return Tuple.Create(true, classesImplementingInterface);
        }
    }
    public class DummyClass
    {
    }
    public interface IHandleMessageG<T>
    {
    }
    public interface IHandleMessage
    {
    }
    public interface IMsgXX
    {
    }
    public interface IMsgXY
    {
    }
    public interface IMsgZZ
    {
    }
    public class MessageHandlerXY : IHandleMessageG<IMsgXY>, IHandleMessage, IMsgXX
    {
        public string Handle(string a)
        {
            return "aaa";
        }
    }
    public class MessageHandlerZZ : IHandleMessageG<IMsgZZ>, IHandleMessage
    {
        public string Handle(string a)
        {
            return "bbb";
        }
    }
