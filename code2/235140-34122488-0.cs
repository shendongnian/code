    using (ZipFile zz = ZipFile.Read(path))
    {
        zz.AlternateEncodingUsage = ZipOption.Always;
        zz.AlternateEncoding = System.Text.Encoding.GetEncoding("ibm852");
        zz.ExtractAll(loc, ExtractExistingFileAction.OverwriteSilently);
    }
