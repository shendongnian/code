    public static string CSharpName(this Type type)
    {
        if (!type.FullName.StartsWith("System"))
            return type.Name;
        var compiler = new CSharpCodeProvider();
        var t = new CodeTypeReference(type);
        var output = compiler.GetTypeOutput(t);
        output = output.Replace("System.","");
        if (output.Contains("Nullable<"))
            output = output.Replace("Nullable","").Replace(">","").Replace("<","") + "?";
        return output;
    }
