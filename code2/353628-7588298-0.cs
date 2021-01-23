    using (var raw = File.Open(inputFileName, FileMode.Open, FileAccess.Read))
    {
        using (var input= new ZipInputStream(raw))
        {
            ZipEntry e;
            while (( e = input.GetNextEntry()) != null)
            {
