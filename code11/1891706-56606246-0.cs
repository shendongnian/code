    var updateMessage = new SignalRMessage
    {
        GroupName = groupName,     
        Target = "notify",
        Arguments = new[] { "Lulz" }
    };
