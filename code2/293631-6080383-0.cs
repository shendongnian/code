    //-----------------------------------------------------------------------------
    // <copyright file="Program.cs" company="DCOM Productions">
    //     Copyright (c) DCOM Productions.  All rights reserved.
    // </copyright>
    //-----------------------------------------------------------------------------
    namespace MultiSocketServerExample {
        using System;
        using System.Net.Sockets;
        using System.Net;
        using System.Collections.Generic;
        class Program {
            static List<Socket> m_ConnectedClients = new List<Socket>();
            static void Main(string[] args) {
                Socket host = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                host.Bind(new IPEndPoint(IPAddress.Any, 9999));
                host.Listen(1);
                while (true) {
                    m_ConnectedClients.Add(host.Accept());
                    Console.WriteLine("A client connected.");
                }
            }
        }
    }
