    static readonly string cs = "C#";
    static readonly string vb = "VB.NET ";
    static void Main(string[] args)
    {
        Console.WriteLine(string.Format($"Entry assembly source language: {GetLanguage(Assembly.GetEntryAssembly().GetSourceLanguage())}"));
        foreach (var t in new[] { typeof(CSLibClass), typeof(VBLibClass) })
            Console.WriteLine($"{t.Name} source language: {GetLanguage(t.GetSourceLanguage())}");
    }
    static string GetLanguage(SourceLanguage sourceLanguage) =>
        sourceLanguage == SourceLanguage.VB ? vb : cs;
		
