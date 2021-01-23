    using CSharpTest.Net.Processes;
    void Exec(string outputFile, Encoding encoding, string program, params string[] args)
    {
        using (TextWriter output = new StreamWriter(outputFile, false, encoding))
        using (ProcessRunner pi = new ProcessRunner(program))
        {
            pi.OutputReceived += delegate(object sender, ProcessOutputEventArgs e)
                                     { output.WriteLine(e.Data); };
            pi.Run(args);
        }
    }
