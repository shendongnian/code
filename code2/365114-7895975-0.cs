    public class MyEventTriggeringClass
    {
        private static readonly ConstructorInfo ObjectCtor =
            typeof(object).GetConstructor(Type.EmptyTypes);
        private static readonly MethodInfo ToBeInvoked =
            typeof(MyEventTriggeringClass)
                .GetMethod("InvokedMethod",
                           BindingFlags.Public | BindingFlags.Static);
        private readonly ModuleBuilder m_module;
        public MyEventTriggeringClass()
        {
            var assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(
                new AssemblyName("dynamicAssembly"),
                AssemblyBuilderAccess.RunAndCollect);
            m_module = assembly.DefineDynamicModule("dynamicModule");
        }
        public void Attach(object source, string @event, object parameter)
        {
            var e = source.GetType().GetEvent(@event);
            if (e == null)
                return;
            var handlerType = e.EventHandlerType;
            var dynamicType = m_module.DefineType("DynamicType" + Guid.NewGuid());
            var thisField = dynamicType.DefineField(
                "parameter", typeof(object),
                FieldAttributes.Private | FieldAttributes.InitOnly);
            var ctor = dynamicType.DefineConstructor(
                MethodAttributes.Public, CallingConventions.HasThis,
                new[] { typeof(object) });
            var ctorIL = ctor.GetILGenerator();
            ctorIL.Emit(OpCodes.Ldarg_0);
            ctorIL.Emit(OpCodes.Call, ObjectCtor);
            ctorIL.Emit(OpCodes.Ldarg_0);
            ctorIL.Emit(OpCodes.Ldarg_1);
            ctorIL.Emit(OpCodes.Stfld, thisField);
            ctorIL.Emit(OpCodes.Ret);
            var dynamicMethod = dynamicType.DefineMethod(
                "Invoke", MethodAttributes.Public, typeof(void),
                GetDelegateParameterTypes(handlerType));
            var methodIL = dynamicMethod.GetILGenerator();
            methodIL.Emit(OpCodes.Ldarg_0);
            methodIL.Emit(OpCodes.Ldfld, thisField);
            methodIL.Emit(OpCodes.Call, ToBeInvoked);
            methodIL.Emit(OpCodes.Ret);
            var constructedType = dynamicType.CreateType();
            var constructedMethod = constructedType.GetMethod("Invoke");
            var instance = Activator.CreateInstance(
                constructedType, new[] { parameter });
            var sink = Delegate.CreateDelegate(
                handlerType, instance, constructedMethod);
            e.AddEventHandler(source, sink);
        }
        private static Type[] GetDelegateParameterTypes(Type handlerType)
        {
            return handlerType.GetMethod("Invoke")
                              .GetParameters()
                              .Select(p => p.ParameterType)
                              .ToArray();
        }
        public static void InvokedMethod(object parameter)
        {
            Console.WriteLine("Value of parameter = " + parameter ?? "(null)");
        }
    }
