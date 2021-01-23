    // Please note: this isn't nice code, and it's not meant to be. It's just quick
    // and dirty to demonstrate the point.
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    
    class Test
    {
        static byte[] buffer;
        
        static void Main(string[] arg)
        {
            TcpClient client = new TcpClient("www.yoda.arachsys.com", 80);
            NetworkStream stream = client.GetStream();
            
            string text = "GET / HTTP/1.1\r\nHost: yoda.arachsys.com:80\r\n" +
                "Content-Length: 0\r\n\r\n";
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
            
            buffer = new byte[1024 * 1024];
            stream.BeginRead(buffer, 0, buffer.Length, ReadCallback, stream);
            Console.ReadLine();
        }
        
        static void ReadCallback(IAsyncResult ar)
        {
            Stream stream = (Stream) ar.AsyncState;
            int bytesRead = stream.EndRead(ar);
            Console.WriteLine(bytesRead);
            Console.WriteLine("Asynchronous read:");
            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, bytesRead));
            string text = "Bad request\r\n";
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
            Console.WriteLine();
            Console.WriteLine("Synchronous:");
            
            StreamReader reader = new StreamReader(stream);
            Console.WriteLine(reader.ReadToEnd());
        }
    }
