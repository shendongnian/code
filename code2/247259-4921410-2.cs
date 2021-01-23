        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.IO;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                TcpListener server = new TcpListener(IPAddress.Any, 5000);
                server.Start();
                Console.WriteLine("Server started");
                string word = "";
                savedObject saved = new savedObject();
    
                while (true)
                {
                    TcpClient connection = server.AcceptTcpClient();
                    Console.WriteLine("connection accepted");
                    ThreadPool.QueueUserWorkItem(saved.ProssecClient, connection);
                }
            }
        }
    }
    
    
    
    
    
    class savedObject
    {
        Dictionary<string, StreamWriter> dic = new Dictionary<string, StreamWriter>();
        StreamReader[] sr1 = new StreamReader[100];
        StreamWriter[] sw1 = new StreamWriter[100];
        string[] name = new string[100];
        int m;
        int a;
        int g;
        string word;
    
        public string AllWords(string sit)
        {
            word += sit + "  ";// here i concat them
            return word;
        }
    
    
        public string word2()
        {
            return word;
        }
    
    
    
        public void ProssecClient(object o)
        {
         
    
            TcpClient connection = o as TcpClient;
            if (connection == null)
            {
                return;
            }
            StreamReader sr = new StreamReader(connection.GetStream());
            StreamWriter sw = new StreamWriter(connection.GetStream());
            sr1[a++] = new StreamReader(connection.GetStream());
            sw1[m++] = new StreamWriter(connection.GetStream());
            string word2 = "";
            sw.WriteLine("Please, fill your name: ");
            name[g++] = sr.ReadLine();
    
            if (name[g] != null && sw1[m] != null)
            {
                dic.Add(name[g], sw1[m]);
            }
            try
            {
                while (true)
                {
                    int i = 0;
                    word2 = AllWords(sr.ReadLine());
    
                    for (i = 0; i < 3; i++)
                    {
                        if (sw1[i] != null)
                        {
                            sw1[i].WriteLine( name[i] + ":  " + word2);// here is the words that are sent..
    
                            sw1[i].Flush();
    
                        }
    
                    }
    
                }
            }
            catch { Console.WriteLine("client left"); }
        }
    
    }
