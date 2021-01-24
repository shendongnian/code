    using System.IO;
    namespace Demo
    {
        public static class Program
        {
            static void Main()
            {
                string sourceFile = @"D:\tmp\source.txt";
                string destFile   = @"D:\tmp\dest.txt";
                MemoryStream ms = new MemoryStream();
                var data = File.ReadAllBytes(sourceFile);
                ms.Write(data, 0, data.Length);
                ms.Position = 0;
                func(ms, sourceFile, destFile);
            }
            public static void func(Stream stream, string tempFilePath, string dstFilePath)
            {
                File.ReadAllLines(tempFilePath);
                stream.Seek(0, SeekOrigin.Begin);
                
                var reader = new StreamReader(stream);
                reader.ReadToEnd();
                stream.Position = 0;
                using (var dstFile = new FileStream(dstFilePath, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(dstFile);
                }
            }
        }
    }
