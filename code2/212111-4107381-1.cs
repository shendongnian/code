	using System;
	using System.Linq;
    using System.Threading;
	using System.Net.NetworkInformation;
	namespace ConsoleApplication1
	{
		class Program
		{
			static void Main(string[] args)
			{
                const double ShutdownValue = 40960000D;
				const string NetEnable = "interface set interface \u0022{0}\u0022 DISABLED";
				const string NetDisable = "interface set interface \u0022{0}\u0022 ENABLED";
				double Incoming = 0;
				double Outgoing = 0;
				double TotalInterface;
				string SelectedInterface = "Local Area Connection";
				NetworkInterface netInt = NetworkInterface.GetAllNetworkInterfaces().Single(n => n.Name.Equals(SelectedInterface));
				for (; ; )
				{
					IPv4InterfaceStatistics ip4Stat = netInt.GetIPv4Statistics();
					Incoming += (ip4Stat.BytesReceived - Incoming);
					Outgoing += (ip4Stat.BytesSent - Outgoing);
					TotalInterface = Incoming + Outgoing;
					string Shutdown = ((TotalInterface > ShutdownValue) ? "YES" : "NO");
					if (Shutdown == "YES")
					{
						System.Diagnostics.Process.Start("netsh", string.Format(NetDisable, SelectedInterface));
					}
					string output = string.Format("Shutdown: {0} | {1} KB/s", Shutdown, TotalInterface.ToString());
					Console.WriteLine(output);
                    Thread.Sleep(3000);
				}
			}
		}
	}
