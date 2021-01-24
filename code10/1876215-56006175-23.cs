    class Program
    {
        static readonly string cs = "C#";
        static readonly string vb = "VB.NET ";
        static readonly string fs = "F#";
        static void Main(string[] args)
        {
            Console.WriteLine(string.Format($"Entry assembly source language: {GetLanguage(Assembly.GetEntryAssembly().GetSourceLanguage())}"));
            foreach (var t in new[] { typeof(CSLibClass), typeof(VBLibClass), typeof(FSLibClass) })
                Console.WriteLine($"{t.Name} source language: {GetLanguage(t.GetSourceLanguage())}");
        }
        static string GetLanguage(SourceLanguage sourceLanguage)
        {
            if (sourceLanguage == SourceLanguage.FSharp)
                return fs;
            else if (sourceLanguage == SourceLanguage.VB)
                return vb;
            return cs;
        }
    }
		
