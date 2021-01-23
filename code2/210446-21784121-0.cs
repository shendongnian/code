    using System;
    using System.IO;
    using System.IO.Compression;
    using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
    {
        foreach (ZipArchiveEntry entry in archive.Entries)
        {
            if (entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase) ||
                entry.FullName.EndsWith(".doc", StringComparison.OrdinalIgnoreCase))
            {
                // FileFinder_FileFound(new FileFinderEventArgs(...))
            }
        }
    }
