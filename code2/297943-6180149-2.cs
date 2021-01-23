    using System.IO;
    class Logger
    {
        static void Main()
        {
            // Create (and open) a new temporary file
            var filename = Path.GetTempFileName();
            var file = File.Open(filename, FileMode.Append);
            // Write bytes to it during the programs lifetime...
            file.Write(new byte[] { 1, 2, 3 }, 0, 3);
            // Just before closing your program, close and delete it
            file.Close();
            File.Delete(filename);
        }
    }
