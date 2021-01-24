    try
        {
            NativeLibrary.SetDllImportResolver(assembly, MapAndLoad);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
