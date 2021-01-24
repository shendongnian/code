    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace GetFileReverse
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                GetFileReverse getFileReverse = new GetFileReverse(FILENAME);
                string line = "";
                while ((line = getFileReverse.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        public class GetFileReverse
        {
            const int BUFFER_SIZE = 1024;
            private FileStream stream { get; set; }
            private string data { get; set; }
            public Boolean SOF { get; set; }
            private long position { get; set; }
            public GetFileReverse(string filename)
            {
                stream = File.OpenRead(filename);
                if (stream != null)
                {
                    position = stream.Seek(0, SeekOrigin.End);
                    SOF = false;
                    data = string.Empty;
                }
                else
                {
                    SOF = true;
                }
            }
            private byte[] ReadStream()
            {
                byte[] bytes = null;
                if (!SOF)
                {
                    bytes = new byte[BUFFER_SIZE];
                    long oldPosition = position;
                    if (position >= BUFFER_SIZE)
                    {
                        position = stream.Seek(-1 * BUFFER_SIZE, SeekOrigin.Current);
                    }
                    else
                    {
                        position = stream.Seek(-1 * position, SeekOrigin.Current);
                    }
                    SOF = position == 0;
                    int size = (int)(oldPosition - position);
                    stream.Read(bytes, 0, size);
                    stream.Seek(-1 * size, SeekOrigin.Current);
                }
                return bytes;
                
            }
            public string ReadLine()
            {
                string line = "";
                while ((position > 0) && (!data.Contains("\r\n")))
                {
                    string temp = Encoding.UTF8.GetString(ReadStream());
                    data = data.Insert(0, temp);
                }
                int lastReturn = data.LastIndexOf("\r\n");
                if (lastReturn == -1)
                {
                    line = null;
                }
                else
                {
                    line = data.Substring(lastReturn + 2);
                    data = data.Remove(lastReturn);
                }
                return line;
            }
        }
    }
