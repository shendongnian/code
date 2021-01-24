using System.IO;
namespace CodeSnippets.IO
{
    /// <summary>
    /// This class demonstrates multiple ways to clone files stored in the file system.
    /// In all cases, the source file is stored in the file system. Where the return type
    /// is a <see cref="MemoryStream"/>, the destination file will be stored only on that
    /// <see cref="MemoryStream"/>. Where the return type is a <see cref="FileStream"/>,
    /// the destination file will be stored in the file system and opened on that
    /// <see cref="FileStream"/>.
    /// </summary>
    /// <remarks>
    /// The contents of the <see cref="MemoryStream"/> instances returned by the sample
    /// methods can be written to a file as follows:
    ///
    ///     var stream = ReadAllBytesToMemoryStream(sourcePath);
    ///     File.WriteAllBytes(destPath, stream.GetBuffer());
    ///
    /// You can use <see cref="MemoryStream.GetBuffer"/> in cases where the MemoryStream
    /// was created using <see cref="MemoryStream()"/> or <see cref="MemoryStream(int)"/>.
    /// In other cases, you can use the <see cref="MemoryStream.ToArray"/> method, which
    /// copies the internal buffer to a new byte array. Thus, GetBuffer() should be a tad
    /// faster.
    /// </remarks>
    public static class FileCloner
    {
        public static MemoryStream ReadAllBytesToMemoryStream(string path)
        {
            byte[] buffer = File.ReadAllBytes(path);
            var destStream = new MemoryStream(buffer.Length);
            destStream.Write(buffer, 0, buffer.Length);
            destStream.Seek(0, SeekOrigin.Begin);
            return destStream;
        }
        public static MemoryStream CopyFileStreamToMemoryStream(string path)
        {
            using FileStream sourceStream = File.OpenRead(path);
            var destStream = new MemoryStream((int) sourceStream.Length);
            sourceStream.CopyTo(destStream);
            destStream.Seek(0, SeekOrigin.Begin);
            return destStream;
        }
        public static FileStream CopyFileStreamToFileStream(string sourcePath, string destPath)
        {
            using FileStream sourceStream = File.OpenRead(sourcePath);
            FileStream destStream = File.Create(destPath);
            sourceStream.CopyTo(destStream);
            destStream.Seek(0, SeekOrigin.Begin);
            return destStream;
        }
        public static FileStream CopyFileAndOpenFileStream(string sourcePath, string destPath)
        {
            File.Copy(sourcePath, destPath, true);
            return new FileStream(destPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        }
    }
}
On top of the above Open XML-agnostic methods, you can also use the following approach, e.g., in case you already have opened an `OpenXmlPackage` such as a `WordprocessingDocument`, `SpreadsheetDocument`, or `PresentationDocument`:
csharp
public void DoWorkCloningOpenXmlPackage()
{
    using WordprocessingDocument sourceWordDocument = WordprocessingDocument.Open(SourcePath, false);
    
    // There are multiple overloads of the Clone() method in the Open XML SDK.
    // This one clones the source document to the given destination path and
    // opens it in read-write mode.
    using var wordDocument = (WordprocessingDocument) sourceWordDocument.Clone(DestPath, true);
    ChangeWordprocessingDocument(wordDocument);
}
All of the above methods correctly clone, or copy, a document. But what is the most efficient one?
Enter our benchmark, which uses the `BenchmarkDotNet` NuGet package:
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using BenchmarkDotNet.Attributes;
using CodeSnippets.IO;
using CodeSnippets.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
namespace CodeSnippets.Benchmarks.IO
{
    public class FileClonerBenchmark
    {
        #region Setup and Helpers
        private const string SourcePath = "Source.docx";
        private const string DestPath = "Destination.docx";
        [Params(1, 10, 100, 1000)]
        public static int ParagraphCount;
        [GlobalSetup]
        public void GlobalSetup()
        {
            CreateTestDocument(SourcePath);
            CreateTestDocument(DestPath);
        }
        private static void CreateTestDocument(string path)
        {
            const string sentence = "The quick brown fox jumps over the lazy dog.";
            string text = string.Join(" ", Enumerable.Range(0, 22).Select(i => sentence));
            IEnumerable<string> texts = Enumerable.Range(0, ParagraphCount).Select(i => text);
            using WordprocessingDocument unused = WordprocessingDocumentFactory.Create(path, texts);
        }
        private static void ChangeWordprocessingDocument(WordprocessingDocument wordDocument)
        {
            Body body = wordDocument.MainDocumentPart.Document.Body;
            Text text = body.Descendants<Text>().First();
            text.Text = DateTimeOffset.UtcNow.Ticks.ToString();
        }
        #endregion
        #region Benchmarks
        [Benchmark(Baseline = true)]
        public void DoWorkUsingReadAllBytesToMemoryStream()
        {
            using MemoryStream destStream = FileCloner.ReadAllBytesToMemoryStream(SourcePath);
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(destStream, true))
            {
                ChangeWordprocessingDocument(wordDocument);
            }
            File.WriteAllBytes(DestPath, destStream.GetBuffer());
        }
        [Benchmark]
        public void DoWorkUsingCopyFileStreamToMemoryStream()
        {
            using MemoryStream destStream = FileCloner.CopyFileStreamToMemoryStream(SourcePath);
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(destStream, true))
            {
                ChangeWordprocessingDocument(wordDocument);
            }
            File.WriteAllBytes(DestPath, destStream.GetBuffer());
        }
        [Benchmark]
        public void DoWorkUsingCopyFileStreamToFileStream()
        {
            using FileStream destStream = FileCloner.CopyFileStreamToFileStream(SourcePath, DestPath);
            using WordprocessingDocument wordDocument = WordprocessingDocument.Open(destStream, true);
            ChangeWordprocessingDocument(wordDocument);
        }
        [Benchmark]
        public void DoWorkUsingCopyFileAndOpenFileStream()
        {
            using FileStream destStream = FileCloner.CopyFileAndOpenFileStream(SourcePath, DestPath);
            using WordprocessingDocument wordDocument = WordprocessingDocument.Open(destStream, true);
            ChangeWordprocessingDocument(wordDocument);
        }
        [Benchmark]
        public void DoWorkCloningOpenXmlPackage()
        {
            using WordprocessingDocument sourceWordDocument = WordprocessingDocument.Open(SourcePath, false);
            using var wordDocument = (WordprocessingDocument) sourceWordDocument.Clone(DestPath, true);
            ChangeWordprocessingDocument(wordDocument);
        }
        #endregion
    }
}
The above benchmark is run as follows:
using BenchmarkDotNet.Running;
using CodeSnippets.Benchmarks.IO;
namespace CodeSnippets.Benchmarks
{
    public static class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<FileClonerBenchmark>();
        }
    }
}
And what are the results on my machine? Which method is the fastest?
ini
BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18362
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.0.100
  [Host]     : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), X64 RyuJIT
  DefaultJob : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), X64 RyuJIT
| Method                                  | ParaCount |      Mean |     Error |    StdDev |    Median | Ratio |
| --------------------------------------- | --------- | --------: | --------: | --------: | --------: | ----: |
| DoWorkUsingReadAllBytesToMemoryStream   | 1         |  1.548 ms | 0.0298 ms | 0.0279 ms |  1.540 ms |  1.00 |
| DoWorkUsingCopyFileStreamToMemoryStream | 1         |  1.561 ms | 0.0305 ms | 0.0271 ms |  1.556 ms |  1.01 |
| DoWorkUsingCopyFileStreamToFileStream   | 1         |  2.394 ms | 0.0601 ms | 0.1100 ms |  2.354 ms |  1.55 |
| DoWorkUsingCopyFileAndOpenFileStream    | 1         |  3.302 ms | 0.0657 ms | 0.0855 ms |  3.312 ms |  2.12 |
| DoWorkCloningOpenXmlPackage             | 1         |  4.567 ms | 0.1218 ms | 0.3591 ms |  4.557 ms |  3.13 |
|                                         |           |           |           |           |           |       |
| DoWorkUsingReadAllBytesToMemoryStream   | 10        |  1.737 ms | 0.0337 ms | 0.0361 ms |  1.742 ms |  1.00 |
| DoWorkUsingCopyFileStreamToMemoryStream | 10        |  1.752 ms | 0.0347 ms | 0.0571 ms |  1.739 ms |  1.01 |
| DoWorkUsingCopyFileStreamToFileStream   | 10        |  2.505 ms | 0.0390 ms | 0.0326 ms |  2.500 ms |  1.44 |
| DoWorkUsingCopyFileAndOpenFileStream    | 10        |  3.532 ms | 0.0731 ms | 0.1860 ms |  3.455 ms |  2.05 |
| DoWorkCloningOpenXmlPackage             | 10        |  4.446 ms | 0.0880 ms | 0.1470 ms |  4.424 ms |  2.56 |
|                                         |           |           |           |           |           |       |
| DoWorkUsingReadAllBytesToMemoryStream   | 100       |  2.847 ms | 0.0563 ms | 0.0553 ms |  2.857 ms |  1.00 |
| DoWorkUsingCopyFileStreamToMemoryStream | 100       |  2.865 ms | 0.0561 ms | 0.0786 ms |  2.868 ms |  1.02 |
| DoWorkUsingCopyFileStreamToFileStream   | 100       |  3.550 ms | 0.0697 ms | 0.0881 ms |  3.570 ms |  1.25 |
| DoWorkUsingCopyFileAndOpenFileStream    | 100       |  4.456 ms | 0.0877 ms | 0.0861 ms |  4.458 ms |  1.57 |
| DoWorkCloningOpenXmlPackage             | 100       |  5.958 ms | 0.1242 ms | 0.2727 ms |  5.908 ms |  2.10 |
|                                         |           |           |           |           |           |       |
| DoWorkUsingReadAllBytesToMemoryStream   | 1000      | 12.378 ms | 0.2453 ms | 0.2519 ms | 12.442 ms |  1.00 |
| DoWorkUsingCopyFileStreamToMemoryStream | 1000      | 12.538 ms | 0.2070 ms | 0.1835 ms | 12.559 ms |  1.02 |
| DoWorkUsingCopyFileStreamToFileStream   | 1000      | 12.919 ms | 0.2457 ms | 0.2298 ms | 12.939 ms |  1.05 |
| DoWorkUsingCopyFileAndOpenFileStream    | 1000      | 13.728 ms | 0.2803 ms | 0.5196 ms | 13.652 ms |  1.11 |
| DoWorkCloningOpenXmlPackage             | 1000      | 16.868 ms | 0.2174 ms | 0.1927 ms | 16.801 ms |  1.37 |
It turns out that `DoWorkUsingReadAllBytesToMemoryStream()` is consistently the fastest method. However, the margin to `DoWorkUsingCopyFileStreamToMemoryStream()` is easily with the margin of error. This means that you should open your Open XML documents on a `MemoryStream` to do your processing whenever possible. And if you don't have to store the resulting document in your file system, this will even be much faster than unnecessarily using a `FileStream`.
Wherever an output `FileStream` is involved, you see a more "significant" difference (noting that a millisecond can make a difference if you process large numbers of documents). And you should note that using `File.Copy()` is actually not such a good approach.
Finally, using the `OpenXmlPackage.Clone()` method or one of its overrides turns out to be the slowest method. This is due to the fact that it involves more elaborate logic than just copying bytes. However, if all you got is a reference to an `OpenXmlPackage` (or effectively one of its subclasses), the `Clone()` method and its overrides are your best choice.
You can find the full source code in my [CodeSnippets][3] GitHub repository. Look at the [CodeSnippets.Benchmark][4] project and [FileCloner][5] class.
  [1]: https://github.com/OfficeDev/Open-XML-SDK
  [2]: https://github.com/EricWhiteDev/Open-Xml-PowerTools
  [3]: https://github.com/ThomasBarnekow/CodeSnippets
  [4]: https://github.com/ThomasBarnekow/CodeSnippets/tree/master/CodeSnippets.Benchmarks
  [5]: https://github.com/ThomasBarnekow/CodeSnippets/blob/master/CodeSnippets/IO/FileCloner.cs
