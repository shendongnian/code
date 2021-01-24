    using (var zip = new ZipFile())
    {
        string[] dirs = Directory.GetDirectories(@"D:\Work\ZippedFile");
        foreach (string dir in dirs)
        {
            if (file.Contains(".zip"))
            {   
                string filename = file.Substring(51);
                zip.AddFile(file, "");
            }
        }
        zip.Password = "Abc!23";
        zip.Encryption = EncryptionAlgorithm.WinZipAes256;
        zip.Save(dir + "\\" + "AllFile.zip");
    } 
