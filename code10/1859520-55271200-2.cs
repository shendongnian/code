    reply.Attachments = new List<Attachment>() { GetInlineAttachment() };
    
    private static Attachment GetInlineAttachment()
    {
        var imagePath = Path.Combine(Environment.CurrentDirectory, @"Resources\architecture-resize.png");
        var imageData = Convert.ToBase64String(File.ReadAllBytes(imagePath));
    
        return new Attachment
        {
            Name = @"Resources\architecture-resize.png",
            ContentType = "image/png",
            ContentUrl = $"data:image/png;base64,{imageData}",
        };
    }
