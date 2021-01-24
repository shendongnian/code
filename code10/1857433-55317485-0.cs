    using DevExpress.Xpo.DB;
    using DevExpress.Xpo.Metadata;
    using StackExchange.Profiling;
    using System.Reflection;
    
    namespace DevExpress.Xpo
    {
        public class ProfiledThreadSafeDataLayer : ThreadSafeDataLayer
        {
            public MiniProfiler Profiler { get { return MiniProfiler.Current; } }
    
            public ProfiledThreadSafeDataLayer(XPDictionary dictionary, IDataStore provider, params Assembly[] persistentObjectsAssemblies) 
                : base(dictionary, provider, persistentObjectsAssemblies) { }
    
            public override ModificationResult ModifyData(params ModificationStatement[] dmlStatements) {
                if (Profiler != null) using (Profiler.CustomTiming("xpo", dmlStatements.ToSql(), nameof(ModifyData))) {
                    return base.ModifyData(dmlStatements);
                }
                return base.ModifyData(dmlStatements);
            }
    
            public override SelectedData SelectData(params SelectStatement[] selects) {
                if (Profiler != null) using (Profiler.CustomTiming("xpo", selects.ToSql(), nameof(SelectData))) {
                    return base.SelectData(selects);
                }
                return base.SelectData(selects);
            }
        }
    }
