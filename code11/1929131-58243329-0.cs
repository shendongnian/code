C#
static public void CopyFolder(string sourceFolder, string destFolder)
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
