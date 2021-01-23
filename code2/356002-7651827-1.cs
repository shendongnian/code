    public Commands HasCommand(string cmd)
    {
        return AllowedCommands.FirstOrDefault(c => c.Alias.Contains(cmd, StringComparer.OrdinalIgnoreCase));
                              
    }
