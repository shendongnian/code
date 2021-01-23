    using (FileStream zipFS = new FileStream(@"c:\Temp\SFImport\test.zip",FileMode.OpenOrCreate))
    {
        using (ZipArchive arch = new ZipArchive(zipFS,ZipArchiveMode.Update))
        {
		    ZipArchiveEntry entry = arch.GetEntry("testfile.txt");
            if (entry == null)
            {
                entry = arch.CreateEntry("testfile.txt");
            }
            using (StreamWriter sw = new StreamWriter(entry.Open()))
            {
                sw.BaseStream.Seek(0,SeekOrigin.End);
                sw.WriteLine("text content");
            }
	    }
    }
