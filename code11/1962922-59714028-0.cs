     string base64 = Convert.ToBase64String(File.ReadAllBytes([The Archive Path]));
---
    using System.Collections.Generic;
    using System.IO; 
    using System.IO.Compression;
    public enum UnZipOptions
    {
        AllFiles,
        FirstFile,
        ListOfFiles
    }
    public IEnumerable<string> UnzipToBase64String(string archivePath, IEnumerable<string> fileList, UnZipOptions options)
    {
        if (options == UnZipOptions.ListOfFiles && (fileList == null | fileList.Count() == 0)) yield break;
        using (ZipArchive archive = new ZipArchive(File.OpenRead(archivePath))) {
            foreach(ZipArchiveEntry entry in archive.Entries) {
                if (options == UnZipOptions.ListOfFiles && 
                    !fileList.Contains(entry.Name, StringComparer.InvariantCultureIgnoreCase))
                    continue;
                using (Stream stream = entry.Open())
                using (MemoryStream ms = new MemoryStream()) {
                    stream.CopyTo(ms);
                    ms.Position = 0;
                    yield return Convert.ToBase64String(ms.ToArray());
                    if (options == UnZipOptions.FirstFile) {
                        yield break;
                    }
                }
            }
        }
    }
