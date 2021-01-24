    public static string MapSymbol(string symbol)
	{
		try
		{
			symbol = symbol.Trim();
			string symbolReturn = null;
			int priority = 5;
			List<string> symbolList = new List<string>() { "AUDCADu", "AUDJPYu", "AUDNZDu", "AUDUSDf", "AUDUSDu", "CADJPYu", "EURAUDu", "EURCADu", "EURCHFu", "EURGBPu", "EURJPYu", "EURNZDu", "EURUSDf", "EURUSDu", "GBPAUDu", "GBPCADu", "GBPCHFu", "GBPJPYu", "GBPNZDu", "GBPUSDf", "GBPUSDu", "GER30u", "HK50u", "JPN225u", "NAS100u", "NZDCADu", "NZDUSDf", "NZDUSDu", "SPX500u", "UK100u", "UKOILu", "US30u", "USDCADf", "USDCADu", "USDCHFf", "USDCHFu", "USDJPYf", "USDJPYu", "USDXu", "USOILu", "XAGUSDf", "XAGUSDfv", "XAGUSDu", "XAUUSDf", "XAUUSDfv", "XAUUSDu", "XINA50u" };
			foreach (var item in symbolList)
			{
				if (item == symbol)
				{
					symbolReturn = item; 
					break; // best priority so no need to look at the rest of the list
				}
				else if (item == symbol.Substring(0, Math.Min(symbol.Length, 6)) && priority > 2)
				{
					priority = 2;
					symbolReturn = item;
				}
				else if (item.Substring(0, Math.Min(item.Length, 6)) == symbol && priority > 3)
				{
					priority = 3;
					symbolReturn = item;
				}
				else if (item.Substring(0, Math.Min(item.Length, 6)) == symbol.Substring(0, Math.Min(symbol.Length, 6)) && priority > 4)
				{
					priority = 4;
					symbolReturn = item;
				}
			}
			return symbolReturn;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Exception in maping symbol, {ex.Message}");
			return null;
		}
	}
