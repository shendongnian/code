    ResolveEventHandler handler = new ResolveEventHandler(CurrentDomain_AssemblyResolve);
    AppDomain.CurrentDomain.AssemblyResolve += handler;
    try
    {
       section = config.GetSection("mySection") as MySection;
    }
    catch(Exception)
    {
    }
    AppDomain.CurrentDomain.AssemblyResolve -= handler;
