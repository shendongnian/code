    StreamReader reader;
    StreamWriter writer;
    Stream stream;
    Assembly assembly = Assembly.GetExecutingAssembly();
    using (stream = assembly.GetManifestResourceStream("Namespace.Stylesheet1.css"))
    using (reader = new StreamReader(stream))
    using (writer = new StreamWriter("test.css"))
    {
        string content = reader.ReadToEnd();
        writer.Write(content);
        writer.Close();
    }     
