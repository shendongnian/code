            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            int wantedPort = 21;    //this is the port you want
            byte[] msg = Encoding.ASCII.GetBytes("type msg here");
 
            foreach (NetworkInterface netwIntrf in NetworkInterface.GetAllNetworkInterfaces())
            {
                Console.WriteLine("Interface name: " + netwIntrf.Name);
                Console.WriteLine("Inteface working: {0}", netwIntrf.OperationalStatus == OperationalStatus.Up);
                //if the current interface doesn't have an IP, skip it
                if (! (netwIntrf.GetIPProperties().GatewayAddresses.Count > 0))
                {
                    break;
                }
                //Console.WriteLine("IP Address(es):");
                //get current IP Address(es)
                foreach (UnicastIPAddressInformation uniIpInfo in netwIntrf.GetIPProperties().UnicastAddresses)
                {
                    //get the subnet mask and the IP address as bytes
                    byte[] subnetMask = uniIpInfo.IPv4Mask.GetAddressBytes();
                    byte[] ipAddr = uniIpInfo.Address.GetAddressBytes();
                    // we reverse the byte-array if we are dealing with littl endian.
                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(subnetMask);
                        Array.Reverse(ipAddr);
                    }
                    //we convert the subnet mask as uint (just for didactic purposes (to check everything is ok now and next - use thecalculator in programmer mode)
                    uint maskAsInt = BitConverter.ToUInt32(subnetMask, 0);
                    //Console.WriteLine("\t subnet={0}", Convert.ToString(maskAsInt, 2));
                    //we convert the ip addres as uint (just for didactic purposes (to check everything is ok now and next - use thecalculator in programmer mode)
                    uint ipAsInt = BitConverter.ToUInt32(ipAddr, 0);
                    //Console.WriteLine("\t ip={0}", Convert.ToString(ipAsInt, 2));
                    
                    //we negate the subnet to determine the maximum number of host possible in this subnet
                    uint validHostsEndingMax = ~BitConverter.ToUInt32(subnetMask, 0);
                    //Console.WriteLine("\t !subnet={0}", Convert.ToString(validHostsEndingMax, 2));
                    //we convert the start of the ip addres as uint (the part that is fixed wrt the subnet mask - from here we calculate each new address by incrementing with 1 and converting to byte[] afterwards 
                    uint validHostsStart = BitConverter.ToUInt32(ipAddr, 0) & BitConverter.ToUInt32(subnetMask, 0);
                    //Console.WriteLine("\t IP & subnet={0}", Convert.ToString(validHostsStart, 2));
                    //we increment the startIp to the number of maximum valid hosts in this subnet and for each we check the intended port (refactoring needed)
                    for (uint i = 1; i <= validHostsEndingMax; i++)
                    {
                        uint host = validHostsStart + i;
                        //byte[] hostAsBytes = BitConverter.GetBytes(host);
                        byte[] hostBytes = BitConverter.GetBytes(host);
                        if (BitConverter.IsLittleEndian)
                        {
                            Array.Reverse(hostBytes);
                        }
                        //this is the candidate IP address in "readable format" 
                        String ipCandidate = Convert.ToString(hostBytes[0]) + "." + Convert.ToString(hostBytes[1]) + "." + Convert.ToString(hostBytes[2]) + "." + Convert.ToString(hostBytes[3]);
                        Console.WriteLine("Trying: " + ipCandidate);
                        
                        try
                        {
                            //try to connect
                            sock.Connect(ipCandidate, wantedPort);
                            if (sock.Connected == true)  // if succesful => something is listening on this port
                            {
                                Console.WriteLine("\tIt worked at " + ipCandidate);
                                sock.Close();
                                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            }
                            //else -. goes to exception
                         }
                        catch (SocketException ex)
                        { 
                            //TODO: if you want, do smth here
                            Console.WriteLine("\tDIDN'T work at " + ipCandidate);
                        }
                    }
                }
                Console.ReadLine();
            }
            sock.Close();
        }
