using (var zip = ZipFile.Open(destinationZip, ZipArchiveMode.Update))
{
    var entry = zip.CreateEntry("Transfer.mp4");
    using (var destinationStream = entry.Open())
    using (var sourceStream = File.OpenRead(sourceFile))
    {
        sourceStream.CopyTo(destinationStream);
    }
}
Or, if you're using `ICSharpCode.SharpZipLib.Zip.ZipFile`, do this:
using (var fileStream = new FileStream(destinationZip, FileMode.Open))
using (var zip = new ZipArchive(fileStream, ZipArchiveMode.Update))
{
    var entry = zip.CreateEntry("Transfer.mp4");
    using (var destinationStream = entry.Open())
    using (var sourceStream = File.OpenRead(sourceFile))
    {
        sourceStream.CopyTo(destinationStream);
    }
}
