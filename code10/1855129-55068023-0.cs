    static ScriptMain()
    {
     AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
    }
    static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        if (args.Name.ToUpper().Contains("NEWTONSOFT"))
        {
       string path = @"C:\DLL File Path\";
       return System.Reflection.Assembly.LoadFile(System.IO.Path.Combine(path, "Newtonsoft.Json.dll"));
        }
        return null;
    }
    public void Main()
    {
        ...
