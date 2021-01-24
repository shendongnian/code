cs
// Try to delete the font file physically.
try
{
    File.Delete(targetFontFile);
}
// Sometimes it's impossible to delete the font because it's in use by another process.
catch (Exception)
{
    // Create the hidden Deleted directory if it doesn't exist.
    var deletedDirectory = Path.Combine(Path.GetDirectoryName(targetFontFile), "Deleted");
    if (!Directory.Exists(deletedDirectory))
    {
        DirectoryInfo di = Directory.CreateDirectory(deletedDirectory);
        di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
    }
    // Move the font file into the Deleted directory.
    File.Move(targetFontFile, Path.Combine(deletedDirectory, Path.GetFileName(targetFontFile).ToUpper()));
}
Windows 10 renames the font file to upper case, so my code does the same.
