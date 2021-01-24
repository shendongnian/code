    DTE dte;
    void OpenFile(string file, string project)
    {
        if (dte == null)
        {
            Type visualStudioType = Type.GetTypeFromProgID("VisualStudio.DTE.16.0");
            dte = Activator.CreateInstance(visualStudioType) as DTE;
        }
        dte.ExecuteCommand("File.OpenProject", project);
        dte.ExecuteCommand("File.OpenFile", file);
        dte.MainWindow.Visible = true;
    }
