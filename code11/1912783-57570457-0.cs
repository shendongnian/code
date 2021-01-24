public static class FileExtensions
{
    public static IEnumerable<FileSystemInfo> AllFilesAndFolders(this DirectoryInfo dir)
    {
        foreach (var f in dir.GetFiles())
            yield return f;
        foreach (var d in dir.GetDirectories())
        {
            yield return d;
            foreach (var o in AllFilesAndFolders(d))
                yield return o;
        }
    }
}
`
And then using your same format, you should be able to do something like so (not tested):
`
DirectoryInfo dir = new DirectoryInfo(m_strWorkingDirectory);
using (ZipArchive archive = ZipFile.Open(Path.Combine(m_strWorkingDirectory, "build.zip"), ZipArchiveMode.Create))
{
    foreach (FileInfo file in dir.AllFilesAndFolders().Where(o => o is FileInfo).Cast<FileInfo>())
    {
        var relPath = file.FullName.Substring(dir.FullName.Length + 1);
        archive.CreateEntryFromFile(file.FullName, relPath);
    }
}
