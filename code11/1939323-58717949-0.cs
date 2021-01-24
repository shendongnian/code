cs
services.AddRazorPages(opt => { opt.RootDirectory = "/"; })
    .AddRazorRuntimeCompilation(
        opt =>
        {
            opt.FileProviders.Add(new PhysicalFileProvider(WebRoot));
            LoadPrivateBinAssemblies(opt);
        });
then:
cs
private void LoadPrivateBinAssemblies(MvcRazorRuntimeCompilationOptions opt)
{
    var binPath = Path.Combine(WebRoot, "PrivateBin");
    if (Directory.Exists(binPath))
    {
        var files = Directory.GetFiles(binPath);
        foreach (var file in files)
        {
            if (!file.EndsWith(".dll", StringComparison.CurrentCultureIgnoreCase) &&
               !file.EndsWith(".exe", StringComparison.InvariantCultureIgnoreCase))
                continue;
            try
            {
                var asm = AssemblyLoadContext.Default.LoadFromAssemblyPath(file);
                opt.AdditionalReferencePaths.Add(file);           
            }
            catch (Exception ex)
            {
                ...
            }
        }
    }
}
The key is:
cs
opt.AdditionalReferencePaths.Add(file);  
which makes the assembly **visible** to Razor, but **doesn't actually load it**. To load it you then have to explicitly load it with:
cs
AssemblyLoadContext.Default.LoadFromAssemblyPath(file);
which loads the assembly from a path. Note that any dependencies that this assembly has have to be available either in the application's startup path or in the same folder you're loading from. 
> Note: Load order for dependencies may be important here or a not previously added assembly may not be found as a dependency (untested).
