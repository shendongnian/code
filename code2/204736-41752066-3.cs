    public bool PrintHtmlPages(
        string printer,
        List<string> urls)
    {
        try {
            // Spawn the code to print the packing slips
            var info = new ProcessStartInfo();
            info.Arguments = $"-p \"{printer}\" \"{string.Join("\" \"", urls)}\"";
            var pathToExe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            info.FileName = Path.Combine(pathToExe, "PrintHtml.exe");
            using (var p = Process.Start(info)) {
                // Wait until it is finished
                while (!p.HasExited) {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(10);
                }
                // Return the exit code
                return p.ExitCode == 0;
            }
        } catch {
            return false;
        }
    }
