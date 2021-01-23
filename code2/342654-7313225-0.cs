    public bool HasCompletedTasks { get; set; }
    public void CompleteAndClose()
    {
        //if (File.Exists(_fileName))
        //    File.Delete(_fileName);
        HasCompletedTasks = true;
        Close();
    }
