    public class DbSetFacade
    {
        private static ReadOnlyDictionary<EfQueryExtensionType, MethodInfo> _extensionMethodInfos = GetExtensionMethodInfos();
        private readonly object _dbSet;
        private readonly ReadOnlyDictionary<EfQueryExtensionType, MethodInfo> _genericInstanceMethodInfos;
        public DbSetFacade(DbContext context, Type entityType)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (entityType == null) throw new ArgumentNullException(nameof(entityType));
            _dbSet = GetDbSetInstance(context, entityType);
            _genericInstanceMethodInfos = new ReadOnlyDictionary<EfQueryExtensionType, MethodInfo>(new Dictionary<EfQueryExtensionType, MethodInfo>
            {
                [EfQueryExtensionType.AsNoTracking] = _extensionMethodInfos[EfQueryExtensionType.AsNoTracking].MakeGenericMethod(entityType),
                [EfQueryExtensionType.ToListAsync] = _extensionMethodInfos[EfQueryExtensionType.ToListAsync].MakeGenericMethod(entityType),
                [EfQueryExtensionType.CountAsyncWithoutPredicate] = _extensionMethodInfos[EfQueryExtensionType.CountAsyncWithoutPredicate].MakeGenericMethod(entityType),
            });
        }
        enum EfQueryExtensionType
        {
            AsNoTracking,
            ToListAsync,
            //FirstOrDefaultAsyncWithPredicate,
            //FirstOrDefaultAsyncWithoutPredicate,
            //ContainsAsync,
            //CountAsyncWithPredicate,
            CountAsyncWithoutPredicate
        }
   
        public Task<int> CountAsync(CancellationToken token = default) => _genericInstanceMethodInfos[EfQueryExtensionType.CountAsyncWithoutPredicate].Invoke(null, new object[] { _dbSet, token }) as Task<int>;
        public async Task<dynamic> ToListAsync(CancellationToken token = default)
        {
            var noTrackingSet = _genericInstanceMethodInfos[EfQueryExtensionType.AsNoTracking].Invoke(null, new object[] { _dbSet });
            var toList = _genericInstanceMethodInfos[EfQueryExtensionType.ToListAsync].Invoke(null, new object[] { noTrackingSet, token }) as Task;
            
            await toList.ConfigureAwait(false);
            return (object)((dynamic)toList).Result;
        }
        private static object GetDbSetInstance(DbContext context, Type type)
        {
            return typeof(DbContext).GetMethods()
                .FirstOrDefault(p => p.Name == "Set" && p.ContainsGenericParameters)
                .MakeGenericMethod(type)
                .Invoke(context, null);
        }
        static ReadOnlyDictionary<EfQueryExtensionType, MethodInfo> GetExtensionMethodInfos()
        {
            var extensionMethods = typeof(EntityFrameworkQueryableExtensions)
                .GetTypeInfo()
                .GetMethods()
                .Where(x => x.ContainsGenericParameters && x.GetParameters()[0].ParameterType.IsGenericType);
            return new ReadOnlyDictionary<EfQueryExtensionType, MethodInfo>(new Dictionary<EfQueryExtensionType, MethodInfo>
            {
                [EfQueryExtensionType.AsNoTracking] = extensionMethods.FirstOrDefault(x => x.Name == "AsNoTracking"),
                [EfQueryExtensionType.ToListAsync] = extensionMethods.FirstOrDefault(x => x.Name == "ToListAsync" && x.GetParameters().Count() == 2),
                [EfQueryExtensionType.CountAsyncWithoutPredicate] = extensionMethods.FirstOrDefault(x => x.Name == "CountAsync" && x.GetParameters().Count() == 2)
            });
        }
    }
