    IEnumerable<Type> interfaces = _assembly.GetTypes().Where(IsInterface);
    List<string> Messages = new List<string>();
    private bool IsInterface(Type x)
    {
        try { return x.IsInterface; }
        catch (Exception e)
        {
            Messages.Add(e.Message);
        }
        return false;
    } 
