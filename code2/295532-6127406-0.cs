    public static class UDPPacket
        {
            public static byte[] Construct(IPAddress sourceAddress, ushort sourcePort, IPAddress destinationAddress, ushort destinationPort, byte[] payload)
            {
                var bindAddress = IPAddress.Any;
    
                // Make sure parameters are consistent
                //if ((sourceAddress.AddressFamily != destinationAddress.AddressFamily) || (sourceAddress.AddressFamily != bindAddress.AddressFamily))
                //{
                //    throw new Exception("Source and destination address families don't match!");
                //}
    
                // Start building the headers
                byte[] builtPacket;
                UdpHeader udpPacket = new UdpHeader();
                ArrayList headerList = new ArrayList();
                //Socket rawSocket = null;
                //SocketOptionLevel socketLevel = SocketOptionLevel.IP;
    
                // Fill out the UDP header first
                Console.WriteLine("Filling out the UDP header...");
                udpPacket.SourcePort = sourcePort;
                udpPacket.DestinationPort = destinationPort;
                udpPacket.Length = (ushort)(UdpHeader.UdpHeaderLength + payload.Length);
                udpPacket.Checksum = 0;
    
                if (sourceAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    Ipv4Header ipv4Packet = new Ipv4Header();
    
                    // Build the IPv4 header
                    Console.WriteLine("Building the IPv4 header...");
                    ipv4Packet.Version = 4;
                    ipv4Packet.Protocol = (byte)ProtocolType.Udp;
                    ipv4Packet.Ttl = 2;
                    ipv4Packet.Offset = 0;
                    ipv4Packet.Length = (byte)Ipv4Header.Ipv4HeaderLength;
                    ipv4Packet.TotalLength = (ushort)System.Convert.ToUInt16(Ipv4Header.Ipv4HeaderLength + UdpHeader.UdpHeaderLength + payload.Length);
                    ipv4Packet.SourceAddress = sourceAddress;
                    ipv4Packet.DestinationAddress = destinationAddress;
    
                    // Set the IPv4 header in the UDP header since it is required to calculate the
                    //    pseudo header checksum
                    Console.WriteLine("Setting the IPv4 header for pseudo header checksum...");
                    udpPacket.ipv4PacketHeader = ipv4Packet;
    
                    // Add IPv4 header to list of headers -- headers should be added in th order
                    //    they appear in the packet (i.e. IP first then UDP)
                    Console.WriteLine("Adding the IPv4 header to the list of header, encapsulating packet...");
                    headerList.Add(ipv4Packet);
                    //socketLevel = SocketOptionLevel.IP;
                }
                else if (sourceAddress.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    Ipv6Header ipv6Packet = new Ipv6Header();
    
                    // Build the IPv6 header
                    Console.WriteLine("Building the IPv6 header...");
                    ipv6Packet.Version = 6;
                    ipv6Packet.TrafficClass = 1;
                    ipv6Packet.Flow = 2;
                    ipv6Packet.HopLimit = 2;
                    ipv6Packet.NextHeader = (byte)ProtocolType.Udp;
                    ipv6Packet.PayloadLength = (ushort)(UdpHeader.UdpHeaderLength + payload.Length);
                    ipv6Packet.SourceAddress = sourceAddress;
                    ipv6Packet.DestinationAddress = destinationAddress;
    
                    // Set the IPv6 header in the UDP header since it is required to calculate the
                    //    pseudo header checksum
                    Console.WriteLine("Setting the IPv6 header for pseudo header checksum...");
                    udpPacket.ipv6PacketHeader = ipv6Packet;
    
                    // Add the IPv6 header to the list of headers - headers should be added in the order
                    //    they appear in the packet (i.e. IP first then UDP)
                    Console.WriteLine("Adding the IPv6 header to the list of header, encapsulating packet...");
                    headerList.Add(ipv6Packet);
                    //socketLevel = SocketOptionLevel.IPv6;
                }
    
                // Add the UDP header to list of headers after the IP header has been added
                Console.WriteLine("Adding the UDP header to the list of header, after IP header...");
                headerList.Add(udpPacket);
    
                // Convert the header classes into the binary on-the-wire representation
                Console.WriteLine("Converting the header classes into the binary...");
                builtPacket = udpPacket.BuildPacket(headerList, payload);
    
                /*
                // Create the raw socket for this packet
                Console.WriteLine("Creating the raw socket using Socket()...");
                rawSocket = new Socket(sourceAddress.AddressFamily, SocketType.Raw, ProtocolType.Udp);
    
                // Bind the socket to the interface specified
                Console.WriteLine("Binding the socket to the specified interface using Bind()...");
                rawSocket.Bind(new IPEndPoint(bindAddress, 0));
    
                // Set the HeaderIncluded option since we include the IP header
                Console.WriteLine("Setting the HeaderIncluded option for IP header...");
                rawSocket.SetSocketOption(socketLevel, SocketOptionName.HeaderIncluded, 1);
    
                try
                {
                    // Send the packet!
                    Console.WriteLine("Sending the packet...");
                    int rc = rawSocket.SendTo(builtPacket, new IPEndPoint(destinationAddress, destinationPort));
                    Console.WriteLine("send {0} bytes to {1}", rc, destinationAddress.ToString());
                }
                catch (SocketException err)
                {
                    Console.WriteLine("Socket error occurred: {0}", err.Message);
                    // http://msdn.microsoft.com/en-us/library/ms740668.aspx
                }
                finally
                {
                    // Close the socket
                    Console.WriteLine("Closing the socket...");
                    rawSocket.Close();
                }
                */
    
                return builtPacket;
            }
        }
