C#
static public void ArchiveCopyFolder(string sourceFolder, string destFolder)
{
    try
    {
        if (!Directory.Exists(sourceFolder))
        {
            Directory.CreateDirectory(archivefolder + destFolder);
            //Copy folder and files
        }
    }
}
