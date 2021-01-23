    using System.Net;
    using System.Net.Sockets;
    public static class ConsoleApp {
        public static void Main() {
            {
                // 192.168.20.54 is my local network with internet accessibility
                var localEndPoint = new IPEndPoint(IPAddress.Parse("192.168.20.54"), port: 0);
                var tcpClient = new TcpClient(localEndPoint);
                // No exception thrown.
                tcpClient.Connect("stackoverflow.com", 80);
            }
            {
                // 192.168.2.49 is my vpn, having no default gateway and unable to forward
                // packages to anything that is outside of 192.168.2.x
                var localEndPoint = new IPEndPoint(IPAddress.Parse("192.168.2.49"), port: 0);
                var tcpClient = new TcpClient(localEndPoint);
                // SocketException: A socket operation was attempted to an unreachable network 64.34.119.12:80
                tcpClient.Connect("stackoverflow.com", 80);
            }
        }
    }
