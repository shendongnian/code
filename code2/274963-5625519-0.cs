    public ILogger GetLogger(string name)
    {
      return Loggers
        .Where(l => l.Metadata.Name.Equals(name))
        .Select(l => l.Value)
        .FirstOrDefault();
    }
