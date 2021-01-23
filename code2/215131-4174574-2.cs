    var messages = new MessageCollection();
    messages.Add(new Message(Severity.Warning, "This is a warning"));
    messages.Add(new Message(Severity.Error, "This is an error"));
    if (messages.Count > 0)
        throw new MessageException(messages);
