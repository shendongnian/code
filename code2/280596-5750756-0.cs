    public static void Print(this FileInfo value)
    {
        Process p = new Process();
        p.StartInfo.FileName = value.FullName;
        p.StartInfo.Verb = "Print";
        p.Start();
    }
