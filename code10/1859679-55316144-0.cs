    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Security;
    using System.Net.Sockets;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    namespace SSLTEST
    {
        class Program
        {
            static X509Certificate2 CER = new X509Certificate2("privatecert.cer","pass");// Has to be a private X509cert with key
            static void Main(string[] args)
            {
                TcpListener listener = new TcpListener(IPAddress.Parse("192.168.178.72"), 443);
                listener.Start();
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("client accepted");
    
                SslStream stream = new SslStream(client.GetStream());
                stream.AuthenticateAsServer(CER, false, System.Security.Authentication.SslProtocols.Tls12, false);
                Console.WriteLine("server authenticated");
    
    
                Console.WriteLine("----client request----");
                Decoder decoder = Encoding.UTF8.GetDecoder();
                StringBuilder request = new StringBuilder();
                byte[] buffer = new byte[2048];
                int bytes = stream.Read(buffer, 0, buffer.Length);
                    
                char[] chars = new char[decoder.GetCharCount(buffer, 0, buffer.Length)];
                decoder.GetChars(buffer, 0, bytes, chars, 0);
                    
                request.Append(chars);
    
                Console.WriteLine(request.ToString());
                Console.WriteLine("---------------------");
    
                String method = request.ToString().Split('\n')[0].Split(' ')[0];
                String requestedfile = request.ToString().Split('\n')[0].Split(' ')[1];
                if (method == "GET" & requestedfile == "/")
                {
                    FileStream datastream = new FileInfo(Environment.CurrentDirectory+@"\"+"index.html").OpenRead();
                    BinaryReader datareader = new BinaryReader(datastream);
                    byte[] data = new byte[datastream.Length];
                    datastream.Read(data, 0, data.Length);
                    datastream.Close();
                    
                    StringBuilder header = new StringBuilder();
                    header.AppendLine("HTTP/1.1 200 OK");
                    header.AppendLine("Content-Length: "+data.Length);
                    header.AppendLine();
    
                    List<Byte> responsedata = new List<byte>();
                    responsedata.AddRange(Encoding.ASCII.GetBytes(header.ToString()));
                    responsedata.AddRange(data);
    
                    stream.Write(responsedata.ToArray(), 0, responsedata.ToArray().Length);
                    Console.WriteLine("- response sent");
                }
    
                stream.Close();
                Console.WriteLine("done!");
                Console.Read();
            }
        }
    }
 
