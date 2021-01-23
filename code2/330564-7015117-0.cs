    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
    
    class Program
    {
        static void Main()
        {
            var test = "foo bar baz";
    
            var compressed = Compress(Encoding.UTF8.GetBytes(test));
            var decompressed = Decompress(compressed);
            Console.WriteLine(Encoding.UTF8.GetString(decompressed));
        }
    
        static byte[] Compress(byte[] data)
        {
            using (var compressedStream = new MemoryStream())
            using (var zipStream = new GZipStream(compressedStream, CompressionMode.Compress))
            {
                zipStream.Write(data, 0, data.Length);
                zipStream.Close();
                return compressedStream.ToArray();
            }
        }
    
        static byte[] Decompress(byte[] data)
        {
            using (var compressedStream = new MemoryStream(data))
            using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
            using (var resultStream = new MemoryStream())
            {
                zipStream.CopyTo(resultStream);
                return resultStream.ToArray();
            }
        }
    }
