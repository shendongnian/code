	public static string AddressM(string addressIn)
    {
		var xmlEntityReplacements = new Dictionary<string, string> {
		 { "Lane$", "Ln" }, { "Avenue", "Ave" }, { "Boulevard", "Blvd" },{ "Street", "St;" }
			//. would match all chars ...
			, { "\\.", "" }  
		};
      	foreach(var kv in xmlEntityReplacements){		
			addressIn = Regex.Replace(addressIn, kv.Key, m => xmlEntityReplacements[kv.Key],
// You might also want RegexOptions.IgnoreCase here
 RegexOptions.Compiled);
		}
			
		return addressIn;
	}
