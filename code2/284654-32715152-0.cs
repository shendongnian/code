			foreach (var iface in NetworkInterface.GetAllNetworkInterfaces())
			{
				if (iface.OperationalStatus == OperationalStatus.Up && iface.NetworkInterfaceType != NetworkInterfaceType.Loopback)
				{
					Console.WriteLine("Interface: {0}\t{1}\t{2}", iface.Name, iface.NetworkInterfaceType, iface.OperationalStatus);
					foreach (var ua in iface.GetIPProperties().UnicastAddresses)
					{
						Console.WriteLine("Address: " + ua.Address);
						try
						{
							using (var client = new TcpClient(new IPEndPoint(ua.Address, 0)))
							{
								client.Connect("ns1.vianett.no", 80);
								var buf = Encoding.UTF8.GetBytes("GET / HTTP/1.1\r\nConnection: close\r\nHost: ns1.vianett.no\r\n\r\n");
								client.GetStream().Write(buf, 0, buf.Length);
								var sr = new StreamReader(client.GetStream());
								var all = sr.ReadToEnd();
								var match = Regex.Match(all, "(?mi)^X-YourIP: (?'a'.+)$");
								Console.WriteLine("Your address is " + (match.Success ? match.Groups["a"].Value : all));
							}
						}
						catch (Exception ex)
						{
							Console.WriteLine(ex.Message);
						}
					}
				}
			}
