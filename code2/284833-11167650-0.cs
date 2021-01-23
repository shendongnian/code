    private static void SelfDebug()
    {
        using (var debugger = new MdbEng())
        {
            string[] output = debugger.Execute("~*e!ClrStack");
            Console.WriteLine(String.Join(Environment.NewLine, output));
        }
    }
