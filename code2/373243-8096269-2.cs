    public void PatchUp(string originalFile, string diffGramFile, string outputFile)
    {
       XmlDocument sourceDoc = new XmlDocument(new NameTable());
       sourceDoc.Load(originalFile);
       XmlTextReader diffgramReader = new XmlTextReader(diffGramFile);
    
       xmlpatch.Patch(sourceDoc, diffgramReader);
    
       XmlTextWriter output = new XmlTextWriter(outputFile, Encoding.Unicode);
       sourceDoc.Save(output);
       output.Close();
    }
