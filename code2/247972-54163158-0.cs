csharp
internal static class MemoryCacheExtensions
{
    static MemoryCacheExtensions()
    {
        const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
        Expression<Func<Func<object, object>>> createGetterExpression = () => CreateObjectGetter<object, object>(null);
        var genericCreateObjectGetterMethodInfo = ((MethodCallExpression)createGetterExpression.Body).Method.GetGenericMethodDefinition();
        // Basic types
        var memoryCacheType = typeof(MemoryCache);
        var getEntryMethodInfo = memoryCacheType.GetMethod("GetEntry", flags);
        // MemoryCacheEntry fields
        Debug.Assert(getEntryMethodInfo != null, nameof(getEntryMethodInfo) + " != null");
        var memoryCacheEntryType = getEntryMethodInfo.ReturnType;
        var valueFieldInfo = memoryCacheEntryType.GetField("_value", flags);
        var usageBucketFieldInfo = memoryCacheEntryType.GetField("_usageBucket", flags);
        var removedCallbackFieldInfo = memoryCacheEntryType.GetField("_callback", flags);
        var seldomUsedFieldsFieldInfo = memoryCacheEntryType.GetField("_fields", flags);
        var slidingExpirationFieldInfo = memoryCacheEntryType.GetField("_slidingExp", flags);
        var absoluteExpirationFieldInfo = memoryCacheEntryType.GetField("_utcAbsExp", flags);
        // SeldomUsedFields fields
        Debug.Assert(seldomUsedFieldsFieldInfo != null, nameof(seldomUsedFieldsFieldInfo) + " != null");
        var seldomUsedFieldsType = seldomUsedFieldsFieldInfo.FieldType;
        var dependenciesFieldInfo = seldomUsedFieldsType.GetField("_dependencies", flags);
        // SentinelEntry fields
        var sentinelEntryType = memoryCacheType.GetNestedType("SentinelEntry", flags);
        var updateCallbackFieldInfo = sentinelEntryType.GetField("_updateCallback", flags);
        GetMemoryCacheEntry = (Func<MemoryCache, string, object>)Delegate
            .CreateDelegate(typeof(Func<MemoryCache, string, object>), getEntryMethodInfo);
        Debug.Assert(valueFieldInfo != null, nameof(valueFieldInfo) + " != null");
        GetMemoryCacheEntryValue = (Func<object, object>)genericCreateObjectGetterMethodInfo
            .MakeGenericMethod(memoryCacheEntryType, valueFieldInfo.FieldType)
            .Invoke(null, new object[] { valueFieldInfo });
        Debug.Assert(usageBucketFieldInfo != null, nameof(usageBucketFieldInfo) + " != null");
        GetMemoryCacheEntryUsageBucket = (Func<object, byte>)genericCreateObjectGetterMethodInfo
            .MakeGenericMethod(memoryCacheEntryType, usageBucketFieldInfo.FieldType)
            .Invoke(null, new object[] { usageBucketFieldInfo });
        Debug.Assert(removedCallbackFieldInfo != null, nameof(removedCallbackFieldInfo) + " != null");
        GetMemoryCacheEntryRemovedCallback = (Func<object, CacheEntryRemovedCallback>)genericCreateObjectGetterMethodInfo
            .MakeGenericMethod(memoryCacheEntryType, removedCallbackFieldInfo.FieldType)
            .Invoke(null, new object[] { removedCallbackFieldInfo });
        GetMemoryCacheEntrySeldomUsedFields = (Func<object, object>)genericCreateObjectGetterMethodInfo
            .MakeGenericMethod(memoryCacheEntryType, seldomUsedFieldsFieldInfo.FieldType)
            .Invoke(null, new object[] { seldomUsedFieldsFieldInfo });
        Debug.Assert(slidingExpirationFieldInfo != null, nameof(slidingExpirationFieldInfo) + " != null");
        GetMemoryCacheEntrySlidingExpiration = (Func<object, TimeSpan>)genericCreateObjectGetterMethodInfo
            .MakeGenericMethod(memoryCacheEntryType, slidingExpirationFieldInfo.FieldType)
            .Invoke(null, new object[] { slidingExpirationFieldInfo });
        Debug.Assert(absoluteExpirationFieldInfo != null, nameof(absoluteExpirationFieldInfo) + " != null");
        GetMemoryCacheEntryAbsoluteExpiration = (Func<object, DateTime>)genericCreateObjectGetterMethodInfo
            .MakeGenericMethod(memoryCacheEntryType, absoluteExpirationFieldInfo.FieldType)
            .Invoke(null, new object[] { absoluteExpirationFieldInfo });
        Debug.Assert(dependenciesFieldInfo != null, nameof(dependenciesFieldInfo) + " != null");
        GetSeldomUsedFieldsDependencies = (Func<object, Collection<ChangeMonitor>>)genericCreateObjectGetterMethodInfo
            .MakeGenericMethod(seldomUsedFieldsType, dependenciesFieldInfo.FieldType)
            .Invoke(null, new object[] { dependenciesFieldInfo });
        Debug.Assert(updateCallbackFieldInfo != null, nameof(updateCallbackFieldInfo) + " != null");
        GetSentinelEntryUpdateCallback = (Func<object, CacheEntryUpdateCallback>)genericCreateObjectGetterMethodInfo
            .MakeGenericMethod(sentinelEntryType, updateCallbackFieldInfo.FieldType)
            .Invoke(null, new object[] { updateCallbackFieldInfo });
    }
    private static Func<MemoryCache, string, object> GetMemoryCacheEntry { get; }
    private static Func<object, object> GetMemoryCacheEntryValue { get; }
    private static Func<object, byte> GetMemoryCacheEntryUsageBucket { get; }
    private static Func<object, CacheEntryRemovedCallback> GetMemoryCacheEntryRemovedCallback { get; }
    private static Func<object, object> GetMemoryCacheEntrySeldomUsedFields { get; }
    private static Func<object, TimeSpan> GetMemoryCacheEntrySlidingExpiration { get; }
    private static Func<object, DateTime> GetMemoryCacheEntryAbsoluteExpiration { get; }
    private static Func<object, Collection<ChangeMonitor>> GetSeldomUsedFieldsDependencies { get; }
    private static Func<object, CacheEntryUpdateCallback> GetSentinelEntryUpdateCallback { get; }
    public static CacheItemPolicy GetCacheItemPolicy(this MemoryCache memoryCache, string key)
    {
        var entry = GetMemoryCacheEntry(memoryCache, key);
        if (entry == null) return null;
        var sentinel = GetMemoryCacheEntry(memoryCache, "OnUpdateSentinel" + key);
        var sentinelValue = sentinel == null ? null : GetMemoryCacheEntryValue(sentinel);
        var usageBucket = GetMemoryCacheEntryUsageBucket(entry);
        var slidingExpiration = GetMemoryCacheEntrySlidingExpiration(entry);
        var absoluteExpiration = GetMemoryCacheEntryAbsoluteExpiration(entry);
        var seldomUsedFields = GetMemoryCacheEntrySeldomUsedFields(entry);
        var changeMonitors = seldomUsedFields == null ? null : GetSeldomUsedFieldsDependencies(seldomUsedFields);
        var removedCallback = GetMemoryCacheEntryRemovedCallback(entry);
        var updatedCallback = sentinelValue == null ? null : GetSentinelEntryUpdateCallback(sentinelValue);
        var cacheItemPolicy = new CacheItemPolicy
        {
            Priority = usageBucket == 0xFF ? CacheItemPriority.NotRemovable : CacheItemPriority.Default,
            AbsoluteExpiration = absoluteExpiration,
            RemovedCallback = removedCallback,
            SlidingExpiration = slidingExpiration,
            UpdateCallback = updatedCallback,
        };
        if (changeMonitors != null)
        {
            foreach (var changeMonitor in changeMonitors)
            {
                cacheItemPolicy.ChangeMonitors.Add(changeMonitor);
            }
        }
        return cacheItemPolicy;
    }
    private static Func<TTarget, TFieldType> CreateGetter<TTarget, TFieldType>(FieldInfo field)
    {
        var fieldReflectedType = field.ReflectedType;
        Debug.Assert(fieldReflectedType != null, "field.ReflectedType != null");
        var methodName = fieldReflectedType.FullName + ".get_" + field.Name;
        var getterMethod = new DynamicMethod(methodName, typeof(TFieldType), new[] { typeof(TTarget) }, true);
        var generator = getterMethod.GetILGenerator();
        if (field.IsStatic)
        {
            generator.Emit(OpCodes.Ldsfld, field);
        }
        else
        {
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ldfld, field);
        }
        generator.Emit(OpCodes.Ret);
        return (Func<TTarget, TFieldType>)getterMethod.CreateDelegate(typeof(Func<TTarget, TFieldType>));
    }
    private static Func<object, TFieldType> CreateObjectGetter<TTarget, TFieldType>(FieldInfo fieldInfo)
    {
        var getter = CreateGetter<TTarget, TFieldType>(fieldInfo);
        return @object => getter((TTarget)@object);
    }
}
