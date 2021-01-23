    using (FileStream fs = new FileStream(newMergedFile, FileMode.Create, FileAccess.Write))
    {
        TextWriter objWriter = new StreamWriter(fs);
        foreach(String fileName in HL7FilePaths)
        {
            using (FileStream frs = new FileStream(fileName,FileMode.Open, FileAccess.Read))
            {
                ObjWriter.AppendStream(frs);
                ObjWriter.Flush(); 
            }
        }
    }
