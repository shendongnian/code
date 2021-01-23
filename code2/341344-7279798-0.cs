    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Net.Sockets;
    using System.Net;
    
    namespace UdpProxy
    {
        class Program
        {
            public static IPEndPoint m_listenEp = null;
            public static EndPoint m_connectedClientEp = null;
            public static IPEndPoint m_sendEp = null;
            public static Socket m_UdpListenSocket = null;
            public static Socket m_UdpSendSocket = null;
    
    
            static void Main(string[] args)
            {
    
                // Creates Listener UDP Server
                m_listenEp = new IPEndPoint(IPAddress.Any, 7900);
                m_UdpListenSocket = new Socket(m_listenEp.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
                m_UdpListenSocket.Bind(m_listenEp);
    
                //Connect to zone IP EndPoint
                m_sendEp = new System.Net.IPEndPoint(IPAddress.Parse("REMOTE_IP_GOES_HERE"), 7900);
                m_connectedClientEp = new System.Net.IPEndPoint(IPAddress.Any, 7900);
    
                byte[] data = new byte[1024];
    
                while (true)
                {
                    if (m_UdpListenSocket.Available > 0)
                    {
    
                        int size = m_UdpListenSocket.ReceiveFrom(data, ref m_connectedClientEp); //client to listener
    
                        if (m_UdpSendSocket == null)
                        {
                            // Connect to UDP Game Server.
                            m_UdpSendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                        }
    
                        m_UdpSendSocket.SendTo(data, size, SocketFlags.None, m_sendEp); //listener to server.
    
                    }
    
                    if (m_UdpSendSocket != null && m_UdpSendSocket.Available > 0)
                    {
                        int size = m_UdpSendSocket.Receive(data); //server to client.
    
                        m_UdpListenSocket.SendTo(data, size, SocketFlags.None, m_connectedClientEp); //listner
    
                    }
                }
    
    
                // Wait for any key to terminate application
                Console.ReadKey();
            }
        }
    }
