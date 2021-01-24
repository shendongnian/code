csharp
var compressor = new SevenZipCompressor( ... snip ...);
compressor.CompressFiles("tmp.7z", @"Testdata\7z_LZMA2.7z");
compressor.ModifyArchive("tmp.7z", new Dictionary<int, string> { { 0, "renamed.7z" }});
using (var extractor = new SevenZipExtractor("tmp.7z"))
{
    Assert.AreEqual(1, extractor.FilesCount);
    extractor.ExtractArchive(OutputDirectory);
}
Assert.IsTrue(File.Exists(Path.Combine(OutputDirectory, "renamed.7z")));
Assert.IsFalse(File.Exists(Path.Combine(OutputDirectory, "7z_LZMA2.7z")));
