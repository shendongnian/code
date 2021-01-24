    var dictionaryPaint = new Dictionary<int,int>
    {
        [1] = 100,
    	[2] = 200,
    	[3] = 300,
    };
    			
    var dictionaryTrim = new Dictionary<string,int>
    {
       [1] = 110,
       [2] = 210,
       [3] = 310,
    };
    if (trimPrice >=1 && trimPrice <= 3 && paintPrice>=1 && paintPrice<=3)
    {
                 
    			gTotal1 = dictionaryPaint[1] * 12;  // Your logic here for gTotal1
    			tgCost = // Your logic here for tgCost
    			nTotal = // Your logic here for nTotal
    			GST = // Your logic here for GST
    			Total = // Your logic here for Total 
                Console.WriteLine("Siding Invoice");
                Console.WriteLine("==================");
                Console.WriteLine(gSide1 + "   Siding Boxes  " + " @" + paintPrice + "=  " + "{0:C}", gTotal1);
                Console.WriteLine(tgTotal2 + "  Trim pieces " + "    @" + trimPrice + "=  " + "{0:C}", tgCost);
                Console.WriteLine("                   Net Total    =  " + ("{0:C}"), nTotal);
                Console.WriteLine("                   GST          =  " + ("{0:C}"), GST);
                Console.WriteLine("                   Delivery Fee =  $250.00");
                Console.WriteLine("                   Total        =  " + ("{0:C}"), Total);
                Console.WriteLine("Press Y to Redo");
                Console.Write("Option ");
    			
    			
    			
                
    }
