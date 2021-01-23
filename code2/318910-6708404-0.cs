			public string Source {get; set;}
			public string Name {get; set;}
			public Dictionary<string, AssetTypeSymbol> AssetTypes {get; set;}
			public Dictionary <string,AssetTypeSymbol>Symbols {get; set;}
		}
		public class AssetTypeSymbol
		{
			public IList<string> Spot {get; set;}
			public IList<string> Fut {get; set;}
		}
	
		public Dictionary<string,Exchange> Exchanges = new Dictionary<string,Exchange>
		{
				{"ICE ECX", new Exchange() {
					Source = "SPC",
					Name = "ICE Futures Europe",
					AssetTypes = new Dictionary<string, AssetTypeSymbol>() {
						{"CER", new AssetTypeSymbol() {
							Spot = new string[] { "ECX CER DAILY FUTURE" },
							Fut = new string[] { "ECX CER FUTURE" }
						}},
						.......... and so on 
