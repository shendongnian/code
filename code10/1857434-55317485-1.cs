    using DevExpress.Xpo.DB;
    using DevExpress.Xpo.Metadata;
    using StackExchange.Profiling;
    
    namespace DevExpress.Xpo
    {
        public class ProfiledSimpleDataLayer : SimpleDataLayer
        {
            public MiniProfiler Profiler { get { return MiniProfiler.Current; } }
    
            public ProfiledSimpleDataLayer(IDataStore provider) : this(null, provider) { }
    
            public ProfiledSimpleDataLayer(XPDictionary dictionary, IDataStore provider) : base(dictionary, provider) { }
    
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
