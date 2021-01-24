    enum KeyCollisionBehavior
    {
        SetValue = 0,
        Skip = 1,
        ThrowIfValueDifferent = 2,
        ThrowAlways = 3,
    }
    internal static class ImmutableDictionaryHelper<TKey, TValue>
    {
        private static readonly MethodInfo OriginPropertyGetter = typeof(ImmutableDictionary<TKey, TValue>)
            .GetProperty("Origin", BindingFlags.Instance | BindingFlags.NonPublic).GetGetMethod(true);
        private static readonly MethodInfo AddMethod = typeof(ImmutableDictionary<TKey, TValue>)
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Static).Where(m => m.Name == "Add" && m.GetParameters().Length == 4).FirstOrDefault();
        private static readonly Type MutationResultType = AddMethod.ReturnType;
        private static readonly MethodInfo FinalizeMethod = MutationResultType
            .GetMethod("Finalize", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        private static readonly Func<TKey, TValue, KeyCollisionBehavior, ImmutableDictionary<TKey, TValue>, ImmutableDictionary<TKey, TValue>> AddAndFinalize = CreateAddAndFinalize();
        private static Func<TKey, TValue, KeyCollisionBehavior, ImmutableDictionary<TKey, TValue>, ImmutableDictionary<TKey, TValue>> CreateAddAndFinalize()
        {
            var method = new DynamicMethod(
                nameof(AddAndFinalize),
                typeof(ImmutableDictionary<TKey, TValue>),
                new[] { typeof(TKey), typeof(TValue), typeof(KeyCollisionBehavior), typeof(ImmutableDictionary<TKey, TValue>) },
                typeof(ImmutableDictionary<TKey, TValue>));
            var ilGen = method.GetILGenerator();
            ilGen.DeclareLocal(OriginPropertyGetter.ReturnType);
            ilGen.DeclareLocal(AddMethod.ReturnType);
            // var origin = dictionary.Origin;
            ilGen.Emit(OpCodes.Ldarg_3);
            ilGen.Emit(OpCodes.Callvirt, OriginPropertyGetter);
            ilGen.Emit(OpCodes.Stloc_0);
            // var result = Add(key, value, behavior, origin)
            ilGen.Emit(OpCodes.Ldarg_0);
            ilGen.Emit(OpCodes.Ldarg_1);
            ilGen.Emit(OpCodes.Ldarg_2);
            ilGen.Emit(OpCodes.Ldloc_0);
            ilGen.Emit(OpCodes.Call, AddMethod);
            ilGen.Emit(OpCodes.Stloc_1);
            // var newDictionary = result.Finalize(dictionary);
            ilGen.Emit(OpCodes.Ldloca_S, 1);
            ilGen.Emit(OpCodes.Ldarg_3);
            ilGen.Emit(OpCodes.Call, FinalizeMethod);
            // return newDictionary;
            ilGen.Emit(OpCodes.Ret);
            var del = method.CreateDelegate(typeof(Func<TKey, TValue, KeyCollisionBehavior, ImmutableDictionary<TKey, TValue>, ImmutableDictionary<TKey, TValue>>));
            var func = (Func<TKey, TValue, KeyCollisionBehavior, ImmutableDictionary<TKey, TValue>, ImmutableDictionary<TKey, TValue>>)del;
            return func;
        }
        public static ImmutableDictionary<TKey, TValue> Add(ImmutableDictionary<TKey, TValue> source, TKey key, TValue value, KeyCollisionBehavior behavior)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            return AddAndFinalize(key, value, behavior, source);
        }
    }
