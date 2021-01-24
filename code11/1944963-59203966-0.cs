csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CodeSnippets.IO;
using Xunit;
namespace CodeSnippets.Tests.IO.Compression
{
    public class ZipArchiveTests
    {
        private static byte[] CreateZipArchiveBytes(IEnumerable<(byte[], string)> files)
        {
            using MemoryStream stream = CreateZipArchiveStream(files);
            return stream.ToArray();
        }
        private static MemoryStream CreateZipArchiveStream(IEnumerable<(byte[], string)> files)
        {
            var stream = new MemoryStream();
            using (CreateZipArchive(stream, files))
                return stream;
        }
        private static ZipArchive CreateZipArchive(Stream stream, IEnumerable<(byte[], string)> files)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (files == null) throw new ArgumentNullException(nameof(files));
            var archive = new ZipArchive(stream, ZipArchiveMode.Create, true);
            foreach ((byte[] fileContent, string fileName) in files)
            {
                ZipArchiveEntry archiveEntry = archive.CreateEntry(fileName);
                using Stream entryStream = archiveEntry.Open();
                entryStream.Write(fileContent, 0, fileContent.Length);
            }
            return archive;
        }
        private static ZipArchive ReadZipArchive(byte[] zipArchiveBytes)
        {
            return new ZipArchive(new MemoryStream(zipArchiveBytes), ZipArchiveMode.Read, false);
        }
        private static byte[] ReadEntryBytes(ZipArchive zipArchive, string entryName)
        {
            ZipArchiveEntry entry = zipArchive.GetEntry(entryName) ?? throw new Exception();
            var entryBytes = new byte[entry.Length];
            using Stream entryStream = entry.Open();
            entryStream.Read(entryBytes, 0, (int) entry.Length);
            return entryBytes;
        }
        private static HttpResponseMessage CreateResponseMessage(byte[] content, string fileName, string mediaType)
        {
            var message = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(content)
            };
            message.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName
            };
            message.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
            message.Content.Headers.ContentLength = content.Length;
            return message;
        }
        [Fact]
        public async Task CreateResponseMessage_ZipArchiveBytes_Success()
        {
            // Arrange.
            const string path = "Resources\\ZipContents.docx";
            string fileName = Path.GetFileName(path);
            byte[] fileContent = File.ReadAllBytes(path);
            byte[] zipArchiveBytes = CreateZipArchiveBytes(new[]
            {
                (fileContent, fileName)
            });
            // Act.
            using HttpResponseMessage message = CreateResponseMessage(zipArchiveBytes, "ZipArchive.zip", "application/zip");
            HttpContent messageContent = message.Content;
            byte[] messageBytes = await messageContent.ReadAsByteArrayAsync();
            // Assert.
            // Original zipArchiveBytes and recevied messageBytes are equal.
            Assert.Equal(zipArchiveBytes, messageBytes);
            // Original file content and received ZIP archive content are equal.
            using ZipArchive zipArchive = ReadZipArchive(messageBytes);
            byte[] entryContent = ReadEntryBytes(zipArchive, fileName);
            Assert.Equal(fileContent.Length, entryContent.Length);
            Assert.Equal(fileContent, entryContent);
        }
        [Fact]
        public void CreateZipArchiveBytes_WordDocument_ZipFileSuccessfullyCreated()
        {
            // Arrange.
            const string path = "Resources\\ZipContents.docx";
            string fileName = Path.GetFileName(path);
            byte[] fileContent = File.ReadAllBytes(path);
            // Act.
            byte[] zipArchiveBytes = CreateZipArchiveBytes(new[]
            {
                (fileContent, fileName)
            });
            File.WriteAllBytes("ZipArchive_Bytes.zip", zipArchiveBytes);
            // Assert.
            using ZipArchive zipArchive = ReadZipArchive(zipArchiveBytes);
            byte[] entryContent = ReadEntryBytes(zipArchive, fileName);
            Assert.Equal(fileContent.Length, entryContent.Length);
            Assert.Equal(fileContent, entryContent);
        }
    }
}
The full source code can be found in my [CodeSnippets][1] GitHub repository.
  [1]: https://github.com/ThomasBarnekow/CodeSnippets
