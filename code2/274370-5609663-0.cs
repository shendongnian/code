    using (MemoryStream ms = new MemoryStream()) {
        BinaryFormatter serializer = new BinaryFormatter();
        serializer.AssemblyFormat = FormatterAssemblyStyle.Simple;
        serializer.Serialize(ms, listViewState);
        return ms.ToArray();
    }
