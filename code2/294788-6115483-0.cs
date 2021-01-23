        int n;
        using(ZipFile zip = ZipFile.Read(zipFile))
        {                
            zip.ExtractProgress += zip_ExtractProgress;
            n = 0;
            foreach (ZipEntry entry in zip)
            {
                n++;
                entry.Extract(destination, ExtractExistingFileAction.OverwriteSilently);                    
            }
            Console.WriteLine("DONE");
        }
