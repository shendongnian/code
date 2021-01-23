    using System;
    using System.IO;
    
    class Program {
        static void Main(string[] args) {
            using (var fs = new FileStream(@"c:\temp\onegigabyte.bin", FileMode.Create, FileAccess.Write, FileShare.None)) {
                fs.SetLength(1024 * 1024 * 1024);
            }
        }
    }
