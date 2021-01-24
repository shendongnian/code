    private static Process CreateProcess(string exePath, string parameter)
    {
        return new Process
        {
            StartInfo =
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = $@"""{exePath}""",
                    Arguments = $@"""{parameter}""",
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
        };
    }
