	public class NetworkComputer {
		private string _domain;
		private string _name;
		private IPAddress[] _addresses = null;
		public string Domain { get { return _domain; } }
		public string Name { get { return _name; } }
		public IPAddress[] Addresses { get { return _addresses; } }
		private NetworkComputer(string domain, string name) {
			_domain = domain;
			_name = name;
			try { _addresses = Dns.GetHostAddresses(name); } catch { }
		}
		public static NetworkComputer[] GetLocalNetwork() {
			var list = new List<NetworkComputer>();
			using(var root = new DirectoryEntry("WinNT:")) {
				foreach(var _ in root.Children.OfType<DirectoryEntry>()) {
					switch(_.SchemaClassName) {
						case "Computer":
							list.Add(new NetworkComputer("", _.Name));
							break;
						case "Domain":
							list.AddRange(_.Children.OfType<DirectoryEntry>().Where(__ => (__.SchemaClassName == "Computer")).Select(__ => new NetworkComputer(_.Name, __.Name)));
							break;
					}
				}
			}
			return list.OrderBy(_ => _.Domain).ThenBy(_ => _.Name).ToArray();
		}
	}
