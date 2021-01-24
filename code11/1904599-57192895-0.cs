    List<string> output = new List<string>();
    proc.OutputDataReceived += (obj, args) =>
    {
        if (args.Data != null)
        {
            if (String.IsNullOrWhiteSpace(args.Data))
                return;
            output.Add(args.Data);
        }
    };
    proc.Exited += (s, args) =>
    {
        foreach (var o in output)
            Console.WriteLine(o);
    }
