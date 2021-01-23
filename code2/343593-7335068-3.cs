    var result = Validate(sender);
    if (result.IsError)
    {
        outputMessages.AppendLine("Please correct...: " + result.Issue);
    }
