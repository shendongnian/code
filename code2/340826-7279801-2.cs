    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net.Sockets;
    using System.Diagnostics;
    using System.Net;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string Address= "*PUT IP ADDRESS HERE WHERE UDP SERVER IS*";
                int UDPPort = *PUT UDP SERVER PORT HERE*;
                UdpRedirect _UdpRedirect = new UdpRedirect() { _address = Address, _Port = UDPPort};
                Thread _Thread = new Thread(_UdpRedirect.Connect);
                _Thread.Name = "UDP";
                _Thread.Start();
                int TCPPort = *PUT TCP PORT HERE FOR TCP PROXY*;       
                TcpRedirect _TcpRedirect = new TcpRedirect(Address, TCPPort);            
            }
        }
        class UdpRedirect
        {
            public string _address;
            public int _Port;
            public UdpRedirect()
            {
            }
    
            public void Connect()
            {
                UdpClient _UdpClient = new UdpClient(_Port);
                int? LocalPort = null;
                while (true)
                {
                    IPEndPoint _IPEndPoint = null;
                    byte[] _bytes = _UdpClient.Receive(ref _IPEndPoint);
                    if (LocalPort == null) LocalPort = _IPEndPoint.Port;
                    bool Local = IPAddress.IsLoopback(_IPEndPoint.Address);
                    string AddressToSend = null;
                    int PortToSend = 0;
                    if (Local)
                    {
                        AddressToSend = _address;
                        PortToSend = _Port;
                    }
                    else
                    {
                        AddressToSend = "127.0.0.1";
                        PortToSend = LocalPort.Value;
                    }
                    _UdpClient.Send(_bytes, _bytes.Length, AddressToSend, PortToSend);
                }
            }
        }
        class TcpRedirect
        {
            public TcpRedirect(string _address, int _Port)
            {
    
                TcpListener _TcpListener = new TcpListener(IPAddress.Any, _Port);
                _TcpListener.Start();
                int i = 0;
                while (true)
                {
                    i++;
                    TcpClient _LocalSocket = _TcpListener.AcceptTcpClient();
                    NetworkStream _NetworkStreamLocal = _LocalSocket.GetStream();
    
                    TcpClient _RemoteSocket = new TcpClient(_address, _Port);
                    NetworkStream _NetworkStreamRemote = _RemoteSocket.GetStream();
                    Console.WriteLine("\n<<<<<<<<<connected>>>>>>>>>>>>>");
                    Client _RemoteClient = new Client("remote" + i)
                    {
                        _SendingNetworkStream = _NetworkStreamLocal,
                        _ListenNetworkStream = _NetworkStreamRemote,
                        _ListenSocket = _RemoteSocket
                    };
                    Client _LocalClient = new Client("local" + i)
                    {
                        _SendingNetworkStream = _NetworkStreamRemote,
                        _ListenNetworkStream = _NetworkStreamLocal,
                        _ListenSocket = _LocalSocket
                    };
                }
            }
            public class Client
            {
                public TcpClient _ListenSocket;
                public NetworkStream _SendingNetworkStream;
                public NetworkStream _ListenNetworkStream;
                Thread _Thread;
                public Client(string Name)
                {
                    _Thread = new Thread(new ThreadStart(ThreadStartHander));
                    _Thread.Name = Name;
                    _Thread.Start();
                }
                public void ThreadStartHander()
                {
                    Byte[] data = new byte[99999];
                    while (true)
                    {
                        if (_ListenSocket.Available > 0)
                        {
                            int _bytesReaded = _ListenNetworkStream.Read(data, 0, _ListenSocket.Available);
                            _SendingNetworkStream.Write(data, 0, _bytesReaded);
                            Console.WriteLine("(((((((" + _bytesReaded + "))))))))))" + _Thread.Name + "\n" + ASCIIEncoding.ASCII.GetString(data, 0, _bytesReaded).Replace((char)7, '?'));
                        }
                        Thread.Sleep(10);
                    }
                }
    
            }
        }
    }
