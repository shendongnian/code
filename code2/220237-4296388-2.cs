    public IIOWriter GetWriter(string name)
    {
      return container
        .GetExports<IIOWriter, INamedMetadata>()
        .Where(e => e.Metadata.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
        .Select(e => e.Value)
        .FirstOrDefault();
    }
