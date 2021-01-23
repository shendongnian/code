    private static Assembly GetAssembly(Project project, string assemblyName)
    {
        Microsoft.VisualStudio.OLE.Interop.IServiceProvider oleSP = 
            project.DTE as Microsoft.VisualStudio.OLE.Interop.IServiceProvider;
        ServiceProvider sp = new ServiceProvider(oleSP);
        DynamicTypeService dts = 
            sp.GetService(typeof(DynamicTypeService)) as DynamicTypeService;
        Microsoft.VisualStudio.Shell.Interop.IVsSolution sln = 
            sp.GetService(typeof(SVsSolution)) as IVsSolution;
        Microsoft.VisualStudio.Shell.Interop.IVsHierarchy hier = null;
        sln.GetProjectOfUniqueName(project.UniqueName, out hier);
        ITypeResolutionService rs = dts.GetTypeResolutionService(hier);
        return rs.GetAssembly(new AssemblyName(assemblyName), true);
    }
