    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main(string[] args)
        {
            var listener = new TcpListener(IPAddress.Loopback, 8080);
            listener.Start();
            while (true)
            {
                using (var client = listener.AcceptTcpClient())
                using (var stream = client.GetStream())
                {
                    var headers = new Dictionary<string, string>();
                    string line = string.Empty;
                    while ((line = ReadLine(stream)) != string.Empty)
                    {
                        var tokens = line.Split(new char[] { ':' }, 2);
                        if (!string.IsNullOrWhiteSpace(line) && tokens.Length > 1)
                        {
                            headers[tokens[0]] = tokens[1].Trim();
                        }
                    }
    
                    var key = new byte[8];
                    stream.Read(key, 0, key.Length);
    
                    var key1 = headers["Sec-WebSocket-Key1"];
                    var key2 = headers["Sec-WebSocket-Key2"];
    
                    var numbersKey1 = Convert.ToInt64(string.Join(null, Regex.Split(key1, "[^\\d]")));
                    var numbersKey2 = Convert.ToInt64(string.Join(null, Regex.Split(key2, "[^\\d]")));
                    var numberSpaces1 = CountSpaces(key1);
                    var numberSpaces2 = CountSpaces(key2);
    
                    var part1 = (int)(numbersKey1 / numberSpaces1);
                    var part2 = (int)(numbersKey2 / numberSpaces2);
    
                    var result = new List<byte>();
                    result.AddRange(GetBigEndianBytes(part1));
                    result.AddRange(GetBigEndianBytes(part2));
                    result.AddRange(key);
    
                    var response =
                        "HTTP/1.1 101 WebSocket Protocol Handshake" + Environment.NewLine +
                        "Upgrade: WebSocket" + Environment.NewLine +
                        "Connection: Upgrade" + Environment.NewLine +
                        "Sec-WebSocket-Origin: " + headers["Origin"] + Environment.NewLine +
                        "Sec-WebSocket-Location: ws://localhost:8080/websession" + Environment.NewLine + 
                        Environment.NewLine;
    
                    var bufferedResponse = Encoding.UTF8.GetBytes(response);
                    stream.Write(bufferedResponse, 0, bufferedResponse.Length);
                    using (var md5 = MD5.Create())
                    {
                        var handshake = md5.ComputeHash(result.ToArray());
                        stream.Write(handshake, 0, handshake.Length);
                    }
                }
            }
        }
    
        static int CountSpaces(string key)
        {
            return key.Length - key.Replace(" ", string.Empty).Length;
        }
    
        static string ReadLine(Stream stream)
        {
            var sb = new StringBuilder();
            var buffer = new List<byte>();
            while (true)
            {
                buffer.Add((byte)stream.ReadByte());
                var line = Encoding.ASCII.GetString(buffer.ToArray());
                if (line.EndsWith(Environment.NewLine))
                {
                    return line.Substring(0, line.Length - 2);
                }
            }
        }
    
        static byte[] GetBigEndianBytes(int value)
        {
            var bytes = 4;
            var buffer = new byte[bytes];
            int num = bytes - 1;
            for (int i = 0; i < bytes; i++)
            {
                buffer[num - i] = (byte)(value & 0xffL);
                value = value >> 8;
            }
            return buffer;
        }
    }
