    public void PatchUp(string originalFile, string diffGramFile, string outputFile)
    {
        var doc = new XmlDocument();
        doc.Load(originalFile);
      
        using (var reader = XmlReader.Create(diffGramFile))
        {
            xmlpatch.Patch(sourceDoc, diffgramReader);
            using (var writer = XmlWriter.Create(outputFile))
            {
                doc.Save(writer);
                output.Close();
            }
            reader.Close();
        }
    }
