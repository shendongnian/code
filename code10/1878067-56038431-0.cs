    public List<string> ScriptFiles => Directory.GetFiles(FilePath, "*.cs").ToList();
    private string selectedScript;
    public string SelectedScript
    {
        get { return selectedScript; }
        set { selectedScript = value; Process.Start(value); }
    }
