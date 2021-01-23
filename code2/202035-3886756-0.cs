    [assembly: PythonModule("mymodule", typeof(MyModuleType)]
    public static class MyModuleType {
        [SpecialName]
        public static void PerformModuleReload(PythonContext context, PythonDictionary dict) {
             context.DomainManager.LoadAssembly(typeof(TypeInAssemblyToLoad));
        }
    }
