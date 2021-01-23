    private static void ExecuteRawFilePrinter() {
        Process process = new Process();
        process.StartInfo.FileName = "c:\\Program Files (x86)\\RawFilePrinter\\RawFilePrinter.exe";
        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        process.StartInfo.Arguments = string.Format("-p \"c:\\Users\\Me\\Desktop\\mypdffile.pdf\" \"Canon Printer\"");
        process.Start();
        process.WaitForExit();
        if (process.ExitCode == 0) {
                //ok
        } else {
                //error
        }
    }
