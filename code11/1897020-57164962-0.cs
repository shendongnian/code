   private void StartSniffer()
        {
            RawCapture rawCapture;
            do
            {
                if ((rawCapture = capturedevice.GetNextPacket()) != null)
                {
                    EthernetPacket Packet = PacketDotNet.Packet.ParsePacket(rawCapture.LinkLayerType, rawCapture.Data) as EthernetPacket;
                    if (Packet == null) { return; }
                    AcceptedPacket acPacket = new AcceptedPacket();
                    acPacket.Packet = Packet;
                    if (Packet.SourceHwAddress.Equals(TargetMAC))
                    {
                        Packet.SourceHwAddress = capturedevice.MacAddress;
                        Packet.DestinationHwAddress = GatewayMAC;
                        capturedevice.SendPacket(Packet);
                        if (acPacket.TCPPacket != null &&
                            ((acPacket.Type.Equals("HTTPS") && acPacket.TCPPacket.PayloadData != null) ||
                             (acPacket.Type.Equals("HTTP") && acPacket.TCPPacket.PayloadData != null)))
                        {
                            materialListView1.BeginInvoke(new Action(() =>
                            {
                                materialListView1.AddObject(acPacket);
                                if (materialListView1.Items.Count > 15 && !ResizeDone)
                                {
                                    olvColumn8.MaximumWidth = 65;
                                    olvColumn8.MinimumWidth = 65;
                                    olvColumn8.Width = 65;
                                    ResizeDone = true;
                                }
                                ListofAcceptedPackets.Add(acPacket);
                            }));
                        }
                    }
                    else if (Packet.SourceHwAddress.Equals(GatewayMAC))
                    {
                        IPv4Packet IPV4 = Packet.Extract(typeof(IPv4Packet)) as IPv4Packet;
                        if (IPV4.DestinationAddress.Equals(Target))
                        {
                            Packet.SourceHwAddress = capturedevice.MacAddress;
                            Packet.DestinationHwAddress = TargetMAC;
                            capturedevice.SendPacket(Packet);
                        }
                        if (Properties.Settings.Default.PacketDirection == "Inbound")
                        {
                            if (acPacket.TCPPacket != null &&
                                ((acPacket.Type.Equals("HTTPS") && acPacket.TCPPacket.PayloadData != null) ||
                                 (acPacket.Type.Equals("HTTP") && acPacket.TCPPacket.PayloadData != null)))
                            {
                                materialListView1.BeginInvoke(new Action(() =>
                                {
                                    materialListView1.AddObject(acPacket);
                                    if (materialListView1.Items.Count > 15 && !ResizeDone)
                                    {
                                        olvColumn8.MaximumWidth = 65;
                                        olvColumn8.MinimumWidth = 65;
                                        olvColumn8.Width = 65;
                                        ResizeDone = true;
                                    }
                                    ListofAcceptedPackets.Add(acPacket);
                                }));
                            }
                        }
                    }
                }
            } while (snifferStarted);
And this is the capture device setup: 
 try
	{
		snifferStarted = true;
		if (capturedevice != null)
		{
			capturedevice.Open(DeviceMode.Promiscuous, 1000);
				capturedevice.Filter = $"(ip and ether src {targetmac.ToLower()}) or (ip and ether src {gatewayMAC.ToLower()} and dst net {Target})";
			
			new Thread(() => { StartSniffer(); }).Start();
		}
		else
		{
			MetroMessageBox.Show(this, "No Capture Device is selected!", "Error", MessageBoxButtons.OK,
				MessageBoxIcon.Error);
		}
	}
	catch (Exception exception)
	{
		MetroMessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK,
			MessageBoxIcon.Error);
	}
Note: this has been done using `Packet.Net` NOT `PcapDotNet`.
