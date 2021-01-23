    static string _scriptTempFilename;
    /// <summary>
    /// Creates a shortcut at the specified path with the given target and
    /// arguments.
    /// </summary>
    /// <param name="path">The path where the shortcut will be created. This should
    ///     be a file with the LNK extension.</param>
    /// <param name="target">The target of the shortcut, e.g. the program or file
    ///     or folder which will be opened.</param>
    /// <param name="arguments">The additional command line arguments passed to the
    ///     target.</param>
    public static void CreateShortcut(string path, string target, string arguments)
    {
        // Get temporary file name
        _scriptTempFilename = Path.GetFileNameWithoutExtension(
            Path.GetTempFileName()) + ".vbs";
        // Generate script and write it in the temporary file
        File.WriteAllText(_scriptTempFilename, String.Format(@"Dim WSHShell
    Set WSHShell = WScript.CreateObject({0}WScript.Shell{0})
    Dim Shortcut
    Set Shortcut = WSHShell.CreateShortcut({0}{1}{0})
    Shortcut.TargetPath = {0}{2}{0}
    Shortcut.WorkingDirectory = {0}{3}{0}
    Shortcut.Arguments = {0}{4}{0}
    Shortcut.Save",
            "\"", path, target, Path.GetDirectoryName(target), arguments),
            Encoding.Unicode);
        // Run the script and delete it after it has finished
        Process process = Process.Start(_scriptTempFilename);
        process.EnableRaisingEvents = true;
        process.Exited += delegate { File.Delete(_scriptTempFilename); };
    }
