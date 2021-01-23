    var emailBody = Merge(newDocument.ManualType, new
    {
        ManualType = newDocument.ManualType.ToString(),
        Message = change.Message,
        NewTitle = newDocument.Title ?? "",
        NewVersion = newDocument.Version ?? "",
        Contact = From,
        Changes = change.ToList(),
    });
