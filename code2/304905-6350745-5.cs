    public IMessageSender GetMessageSender(string name)
    {
      return Senders
        .Where(l => l.Metadata.Name.Equals(name))
        .Select(l => l.Value)
        .FirstOrDefault();
    }
