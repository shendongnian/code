    using (FileStream fs = new FileStream(newMergedFile, FileMode....))
    {
        TextWriter objWriter = new StreamWriter(fs);
        foreach(String fileName in HL7FilePaths)
        {
            using (FileStream frs = new FileStream(fileName,FileMode...))
            {
                TextReader reader = new StreamReader(frs);
                ObjWriter.AppendStream(reader);
                ObjWriter.Flush(); 
            }
        }
    }
