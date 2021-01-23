    var assembly = System.Reflection.Assembly.GetExecutingAssembly();
    using (var stream = assembly.GetManifestResourceStream("SomeNamespace.somefile.png"))
    {
        byte[] buffer = new byte[stream.Length];
        stream.Read(buffer, 0, buffer.Length);
        // TODO: use the buffer that was read
    }
