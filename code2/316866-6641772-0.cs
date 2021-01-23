    public static class AssemblyLoader
    {
        public delegate void LoadDelegate(string path);
        public void LoadAssembly(string path)
        {
            if(OnPreLoad != null)
                OnPreLoad(path);
            // load assembly here
        }  // eo LoadAssembly
        public event LoadDelegate OnPreLoad;
    } // eo AssemblyLoader
