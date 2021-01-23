    public void CheckNullParams(MethodBase method, params object[] args)
    {
        for (var i=0; i < args.Count(); i++)
        {
            if (args[i] == null)
            {
                throw new ArgumentNullException(method.GetParameters()[i].Name);
            }
        }
    }
