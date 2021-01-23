    using System;
    using System.Linq;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    namespace ConsoleApplication {
        public static class ConsoleApp {
            public static void Main() {
                var nics = NetworkInterface.GetAllNetworkInterfaces();
                foreach (var nic in nics) {
                    var ipProps = nic.GetIPProperties();
                    // We're only interested in IPv4 addresses for this example.
                    var ipv4Addrs = ipProps.UnicastAddresses
                        .Where(addr => addr.Address.AddressFamily == AddressFamily.InterNetwork);
                    foreach (var addr in ipv4Addrs) {
                        var network = CalculateNetwork(addr);
                        if (network != null)
                            Console.WriteLine("Addr: {0}   Mask: {1}  Network: {2}", addr.Address, addr.IPv4Mask, network);
                    }
                }
            }
            private static IPAddress CalculateNetwork(UnicastIPAddressInformation addr) {
                // The mask will be null in some scenarios, like a dhcp address 169.254.x.x
                if (addr.IPv4Mask == null)
                    return null;
                var ip = addr.Address.GetAddressBytes();
                var mask = addr.IPv4Mask.GetAddressBytes();
                var result = new Byte[4];
                for (int i = 0; i < 4; ++i) {
                    result[i] = (Byte)(ip[i] & mask[i]);
                }
                return new IPAddress(result);
            }
        }
    }
