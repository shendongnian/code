    public Commands HasCommand(string cmd)
    {
        foreach (Commands item in AllowedCommands)
        {
            if (item.Alias.ContainsKey(cmd))
                return item;
        }
        return null;
    }
