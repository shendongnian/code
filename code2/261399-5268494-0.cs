    public delegate string GetStringHandler();
    public string GetDocumentText()
    {
        if (InvokeRequired)
            return Invoke(new GetStringHandler(GetDocumentText)) as string;
        else
            return webBrowser.DocumentText;
    }
    if (regAddId.IsMatch(GetDocumentText()))
    {
    }
