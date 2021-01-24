    public interface IBar
    {
        string BarBar(string a1, string a2);
    }
    
    public class Bar : IBar
    {
        public string BarBar(string a1, string a2) => a1 + a2;
    }
    
    public interface IFoo
    {
        string FooFoo(string a1, string a2);
    }
    
    public class Foo : IFoo
    {
        public IBar Bar { get; private set; }
    
        public Foo(IBar bar)
        {
            Bar = bar;
        }
        public string FooFoo(string a1, string a2) => Bar.BarBar(a2, a1);
    }
    
    public class DummyDispatchProxyDontUseAtWork : DispatchProxy
    {
        public object Instance { get; protected set; }
    
        public DummyDispatchProxyDontUseAtWork() : base()
        {}
    
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            Console.WriteLine($"{targetMethod.Name}({string.Join(',', args)})");
            var result = targetMethod.Invoke(this.Instance, args);
            Console.WriteLine($"   {targetMethod.Name} -> {result}");
            return result;
        }
    
        private static readonly ConcurrentDictionary<Type, Type> generatedProxyTypes = new ConcurrentDictionary<Type, Type>();
        protected static readonly ConcurrentDictionary<string, object> privateHackedState = new ConcurrentDictionary<string, object>();
        private static readonly AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString()), AssemblyBuilderAccess.Run);
        private static readonly ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(Guid.NewGuid().ToString());
    
        private static Type EmitDispatchProxyType(Type interfaceType)
        {
            object dispatchProxyObj = typeof(DispatchProxy).GetMethod("Create", BindingFlags.Static | BindingFlags.Public)
                .MakeGenericMethod(interfaceType, typeof(DummyDispatchProxyDontUseAtWork))
                .Invoke(null, null);
    
            string typeId = "DummyDispatchProxyDontUseAtWork" + Guid.NewGuid().ToString("N");
            privateHackedState[typeId] =
                dispatchProxyObj.GetType().GetField("invoke", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(dispatchProxyObj);
    
            var resultTypeBuilder = moduleBuilder.DefineType(
                typeId,
                TypeAttributes.Public, 
                dispatchProxyObj.GetType());
    
            var baseCtor = dispatchProxyObj.GetType().GetConstructors().First();
    
            var ctor = resultTypeBuilder.DefineConstructor(
                MethodAttributes.Public,
                CallingConventions.Standard,
                new[] {interfaceType});
    
            var il = ctor.GetILGenerator();
    
            il.Emit(OpCodes.Ldarg_0);
            
            il.Emit(OpCodes.Ldsfld, typeof(DummyDispatchProxyDontUseAtWork).GetField(nameof(privateHackedState), BindingFlags.NonPublic | BindingFlags.Static));
            il.Emit(OpCodes.Ldstr, typeId);
            il.Emit(OpCodes.Callvirt, typeof(ConcurrentDictionary<,>).MakeGenericType(typeof(string), typeof(object)).GetMethod("get_Item"));
            il.Emit(OpCodes.Call, baseCtor);
    
            var setInstanceMethodInfo = dispatchProxyObj.GetType()
                .GetMethod("set_" + nameof(Instance),BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Call, setInstanceMethodInfo);
    
            il.Emit(OpCodes.Ret);
    
            return resultTypeBuilder.CreateType();
        }
    
        public static Type GenerateStructureMapCompatibleDispatchProxyType(Type interfaceType)
        {
            return generatedProxyTypes.GetOrAdd(interfaceType, EmitDispatchProxyType);
        }
    }
