    public static void Main()
    {
    	inventoryBLL inv = new inventoryBLL();
    	DataSet1.sDataTable dtsku = inv.SelectEverything();
    	foreach (var items in dtsku.Select(r => r.item).SplitIntoGroups(10))
    	{
    		webservicefunction(items);
    	}
    }
