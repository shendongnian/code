    using System;
    using System.IO;
    using System.Text;
    
    namespace ConsoleApplication6
    {
      public class Program
      {
        public static void Main(String[] args)
        {
          (new Program()).Run();
        }
    
        public void Run()
        {
          this.SaveData(@"c:\temp\test.ppm", "ÿÿ ÿÿ ÿÿ ÿÿ aa aa aa ÿÿ ÿÿ ÿÿ ÿÿ ÿÿ ÿÿ ÿÿ ÿÿ ÿÿ ÿÿ ÿ", 100, 200, Encoding.GetEncoding(1252));
        }
    
        private void SaveData(String filename, String data, Int32 width, Int32 height, Encoding encoding)
        {
          const Int32 bufferSize = 2048;
          Directory.CreateDirectory(Path.GetDirectoryName(filename));      
          if (Path.GetExtension(filename).ToLower() != ".ppm")
            filename += ".ppm";
    
          using (var fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite, FileShare.None, bufferSize))
          {
            using (var bw = new BinaryWriter(fs, encoding))
            {
              var buffer = encoding.GetBytes(this.GetHeader(width, height));
              bw.Write(buffer);
    
              buffer = encoding.GetBytes(data);
              bw.Write(buffer);
            }
          }
        }
    
        private String GetHeader(Int32 width, Int32 height)
        {
          return String.Format("P6 {0} {1} 255 ", width, height);
        }
      }
    }
