    String assemblyPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
    Process proc = new Process();
    proc.StartInfo = new ProcessStartInfo()
    {
        FileName = assemblyPath + "\\Docs\\somePDF.pdf"
    };
    proc.Start();
