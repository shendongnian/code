    try
    {
        var message = new EmailMessage
        {
            Subject = "Hello",
            Body = "World",
        };
        var fn = "attachment.pdf";
        var filePath = Path.Combine(FileSystem.CacheDirectory, fn);
        string folderPath = DependencyService.Get<IDirectoryService>().SavePath(pdfStream, filePath);
        message.Attachments.Add(new EmailAttachment(folderPath));
        await _emailService.ComposeAsync(message);
    }
    catch (FeatureNotSupportedException)
    {
        await PageDialogService.DisplayAlertAsync("", "Email is not supported on this device", "Ok");
    }
    catch (Exception ex)
    {
    }
