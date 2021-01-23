    public static bool IsDllOfuscated(string dirFile)
    {
        Assembly assembly = Assembly.Load(File.ReadAllBytes(dirFile));
        var type = assembly.GetType("DotfuscatorAttribute");
        if (type != null)
            return true;
        return false;
    }
