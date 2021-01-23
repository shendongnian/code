    namespace WakeOnLan
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			if(args.Length==1)
    			{
    				string bytes = args[0].Replace("-", "");
    				long l = 0;
    				if (bytes.Length != 12 || !long.TryParse(bytes.Substring(0, 6), NumberStyles.HexNumber, null, out l) || !long.TryParse(bytes.Substring(6), NumberStyles.HexNumber, null, out l))
    					Console.WriteLine("Invalid string");
    				else
    				{
    					try
    					{
    						WakeOnLan(bytes);
    						Console.WriteLine("Sent wake on lan");
    					}
    					catch (Exception e)
    					{
    						Console.WriteLine(e.ToString());
    					}
    				}
    			}
    			else
    			{
    				Console.WriteLine("WakeOnLan.exe <MAC Address>\r\nMAC address must be 6 bytes in hexadecimal format, optionally separated by hyphen.");
    			}
    		}
    
    		private static void WakeOnLan(string bytesString)
    		{
    			List<byte> packet = new List<byte>();
    			for (int i = 0; i < 6; i++)
    			{
    				packet.Add(byte.Parse(bytesString.Substring(i*2,2),NumberStyles.HexNumber));
    			}
    
    			byte[] mac = packet.ToArray();
    			for (int i = 0; i < 15; i++)
    			{
    				packet.AddRange(mac);
    			}
    			for (int i = 0; i < 6; i++)
    			{
    				packet.Insert(0, 0xFF);
    			}
    
    			UdpClient client = new UdpClient();
    			client.Connect(IPAddress.Broadcast, 7); //Any UDP port will work, but 7 is my lucky number ... 
    			client.Send(packet.ToArray(), packet.Count); 
    		}
    
    	}
    }
