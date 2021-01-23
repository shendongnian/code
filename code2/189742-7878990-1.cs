    Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        if (args.Name == "Dead.Beef.Rocks")
        {
            return typeof(MySection).Assembly;
        }
        return null;
    }
   
