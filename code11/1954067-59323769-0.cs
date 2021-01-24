    public static string MapSymbol(string symbol)
    {
    	try
    	{
    		symbol = symbol.Trim();
    		string symbolReturn = "";
    
    		List<string> symbolList = new List<string>() { "AUDCADu", "AUDJPYu", "AUDNZDu", "AUDUSDf", "AUDUSDu", "CADJPYu", "EURAUDu", "EURCADu", "EURCHFu", "EURGBPu", "EURJPYu", "EURNZDu", "EURUSDf", "EURUSDu", "GBPAUDu", "GBPCADu", "GBPCHFu", "GBPJPYu", "GBPNZDu", "GBPUSDf", "GBPUSDu", "GER30u", "HK50u", "JPN225u", "NAS100u", "NZDCADu", "NZDUSDf", "NZDUSDu", "SPX500u", "UK100u", "UKOILu", "US30u", "USDCADf", "USDCADu", "USDCHFf", "USDCHFu", "USDJPYf", "USDJPYu", "USDXu", "USOILu", "XAGUSDf", "XAGUSDfv", "XAGUSDu", "XAUUSDf", "XAUUSDfv", "XAUUSDu", "XINA50u" };
    
            // functions can be saved as Func<string, string, bool>
            // that means it takes 2 strings as input parameters and returns a bool
    		List<Func<string, string, bool>> TestCases = new List<System.Func<string, string, bool>>()
    		{
    			(item, sym) => item == sym,
    			(item, sym) => item == sym.Substring(0, Math.Min(sym.Length, 6)),
    			(item, sym) => item.Substring(0, Math.Min(item.Length, 6)) == sym.Substring(0, Math.Min(sym.Length, 6))
    		};
    		
    		bool matchFound = false;
            // iteration over each test rules
    		foreach (var test in TestCases)
    		{
                // iteration ver your collection
    			foreach (var item in symbolList)
    			{
                    // test for a match
    				if(test(item, symbol))
    				{
    					matchFound = true;
    					symbolReturn = item;
    				}
    			}
    			
    			if (matchFound)
    			{
    				break;
    			}
    		}
    
    		return matchFound ? symbolReturn : null;
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine($"Exception in maping symbol, {ex.Message}");
    		return null;
    	}	
    }
