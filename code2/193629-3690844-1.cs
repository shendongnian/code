    namespace ConsoleApplication1
    {
        using System;
        using System.Collections.Generic;
        using System.Net;
        using System.Net.NetworkInformation;
        using System.Net.Sockets;
    
        class Program
        {
            public static List<IPAddress> GetInternetIPAddressUsingSocket(string internetHostName, int port)
            {
                // get remote host  IP. Will throw SocketExeption on invalid hosts
                IPHostEntry remoteHostEntry = Dns.GetHostEntry(internetHostName);
                IPEndPoint remoteEndpoint = new IPEndPoint(remoteHostEntry.AddressList[0], port);
    
                // Get all locals IP
                IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
    
                var internetIPs = new List<IPAddress>();
                // try to connect using each IP             
                foreach (IPAddress ip in hostEntry.AddressList) {
                    IPEndPoint localEndpoint = new IPEndPoint(ip, 80);
    
                    bool endpointIsOK = true;
                    try {
                        using (Socket socket = new Socket(localEndpoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)) {
                            socket.Connect(remoteEndpoint);
                        }
                    }
                    catch (Exception) {
                        endpointIsOK = false;
                    }
    
                    if (endpointIsOK) {
                        internetIPs.Add(ip); // or you can return first IP that was found as single result.
                    }
                }
    
                return internetIPs;
            }
    
            public static HashSet <IPAddress> GetInternetIPAddress(string internetHostName)
            {
                // get remote IPs
                IPHostEntry remoteMachineHostEntry = Dns.GetHostEntry(internetHostName);
    
                var internetIPs = new HashSet<IPAddress>();
    
                // connect and search for local IP
                WebRequest request = HttpWebRequest.Create("http://" + internetHostName);
                using (WebResponse response = request.GetResponse()) {
                    IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
                    TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
                    response.Close();
    
                    foreach (TcpConnectionInformation t in connections) {
                        if (t.State != TcpState.Established) {
                            continue;
                        }
    
                        bool isEndpointFound = false;
                        foreach (IPAddress ip in remoteMachineHostEntry.AddressList) {
                            if (ip.Equals(t.RemoteEndPoint.Address)) {
                                isEndpointFound = true;
                                break;
                            }
                        }
    
                        if (isEndpointFound) {
                            internetIPs.Add(t.LocalEndPoint.Address);
                        }
                    }
                }
    
                return internetIPs;
            }
    
    
            static void Main(string[] args)
            {
    
                List<IPAddress> internetIP = GetInternetIPAddressUsingSocket("google.com", 80);
                foreach (IPAddress ip in internetIP) {
                    Console.WriteLine(ip);
                }
    
                Console.WriteLine("======");
    
                HashSet<IPAddress> internetIP2 = GetInternetIPAddress("google.com");
                foreach (IPAddress ip in internetIP2) {
                    Console.WriteLine(ip);
                }
    
                Console.WriteLine("Press any key");
                Console.ReadKey(true);
            }
        }
    }
