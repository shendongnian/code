    using (Stream stream = assembly.GetManifestResourceStream(xmlname))
    {
        var l = stream.Length;
        StreamReader reader = new StreamReader(stream);
        string text = reader.ReadToEnd();
    
        using (TextReader reader = new StringReader(text))
        {
            var ret_obj = ktAntragsdatenAbrufenXmlFormat.Deserialize(stream);
        }
    }
