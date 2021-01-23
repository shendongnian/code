    using System.IO;
    ...
    FileInfo fi = new FileInfo(@"c:\path\to\file");
    long fileSize = fi.Length;
    ...
    // assuming List<string> for attachment file names
    foreach (string attachFile in attachments)
    {
        using (FileStream afs = new FileStream(attachFile))
        {
            byte[] buffer = new byte[1024];
            while (!afs.EndOfstream)
            {
                int br = afs.Read(buffer, 0, 1024);
                // assume targetStream is the NetworkStream or FileStream that you want to write to
                targetStream.Write(buffer, 0, br);
            }
        }
    }
