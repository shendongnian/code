    private Task CopyFile()
    {
        var fh = new FileHelper();
        if (await fh.CopyFiles(@"C:\Test\Destination\", fileList.ToList()))
            Messenger.Default.Send("Files copying finished", "VM");
        else
            Messenger.Default.Send("Files copying failed", "VM");
    }
    private async void Action_Job(object tag)
    {
        if (tag == null || string.IsNullOrEmpty(tag.ToString()))
            return;
        switch (tag.ToString())
        {
            case "GET": GetFile();  break;
            case "COPY": await CopyFile(); break;
        }
    }
