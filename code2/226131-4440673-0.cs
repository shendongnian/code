    void process_Exited(object sender, EventArgs e)
    {
        var process = (Process)sender;
        using (var f = File.CreateText(@"..."))
        {
            f.WriteLine(process.StandardOutput.ReadToEnd());
        }
    }
