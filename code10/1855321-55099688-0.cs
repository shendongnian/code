    var ev = new Event
    {
        Start = start,
        End = end,
        IsAllDay = false,
        Location = location,
        Subject = subject
    };
    //1.create an event first 
    var evResp = await graphServiceClient.Users[userId].Calendar.Events.Request().AddAsync(ev);
            
    byte[] contentBytes = System.IO.File.ReadAllBytes(localPath);
    var attachmentName = System.IO.Path.GetFileName(localPath);
    var fa = new FileAttachment
    {
        ODataType = "#microsoft.graph.fileAttachment",
        ContentBytes = contentBytes,
        ContentType = MimeMapping.GetMimeMapping(attachmentName),
        Name = attachmentName,
        IsInline = false
    };
    //2. add attachments to event
    var faResp = await graphServiceClient.Users[userId].Calendar.Events[evResp.Id].Attachments.Request().AddAsync(fa);
