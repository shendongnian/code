    public static Object GetCOMService(IServiceProvider provider, Type type)
    {
        Object ret;
        ret = provider.GetService(type);
        if (ret == null)
        {
            return ret;
        }
    
        try
        {
            return Marshal.GetObjectForIUnknown(Marshal.GetIUnknownForObject(ret));
        }
        catch (Exception)
        {
            return ret;
        }
    }
