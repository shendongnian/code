    public Commands HasCommand(string cmd)
    {
        return AllowedCommands.Where(c => c.Alias.Contains(cmd, StringComparer.OrdinalIgnoreCase))
                              .FirstOrDefault();
    }
