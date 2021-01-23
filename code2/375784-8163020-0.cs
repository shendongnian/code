    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class StringListModuleExportAttribute : ExportAttribute, IModuleExport
    {
        public StringListModuleExportAttribute(Type moduleType)
            : base(typeof(IModule))
        {
            ModuleName = moduleType.Name;
            ModuleType = moduleType;
        }
    
        public string ModuleName { get; private set; }
        public Type ModuleType { get; private set; }
        public InitializationMode InitializationMode { get; private set; }
        public string[] DependsOnModuleNames
        {
            get
            {
                if (string.IsNullOrEmpty(DependsOnModuleNameList))
                    return new string[0];
                return DependsOnModuleNameList.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    
        public string DependsOnModuleNameList { get; set; }
    }
