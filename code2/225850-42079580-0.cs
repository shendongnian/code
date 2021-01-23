     try
        {
           AppDomain.Unload(otherAssemblyDomain);
        }
        catch (CannotUnloadAppDomainException)
        {
           GC.Collect();
           AppDomain.Unload(otherAssemblyDomain);
        }
