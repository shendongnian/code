    void Main()
    {
    	var dataGenerator = new DataGenerator();
    	var allocations = dataGenerator.Generate();
    	var xlFile = new FileInfo(@"d:\so-test.xlsx");
    	
    	if (xlFile.Exists)
    	{
    		xlFile.Delete();
    	}
    	
    	using(var xl = new ExcelPackage(xlFile))
    	{
    		FundAllocationsPrinter.Print(xl, allocations);
    		xl.Save();
    	}
    }
    
    // Define other methods and classes here
    public static class FundAllocationsPrinter
    {
        public static void Print(ExcelPackage package, ILookup<string, FIRMWIDE_MANAGER_ALLOCATION> allocation)
        {
            ExcelWorksheet wsSheet1 = package.Workbook.Worksheets.Add("Sheet1");
            wsSheet1.Protection.IsProtected = false;
    
            IEnumerable<FIRMWIDE_MANAGER_ALLOCATION> allocationGroup = null;
    
            var rowNumber = 1;
            int tableIndex = 0;
    
            var showFilter = true;
            var showHeader = true;
            var showTotals = true;
            var rowAdderForHeader = Convert.ToInt32(showHeader);
            var rowAdderForFooter = Convert.ToInt32(showTotals);
    
            foreach (var ag in allocation)
            {
                tableIndex += 1;
                Console.WriteLine(tableIndex);
    
                allocationGroup = ag.Select(a => a);
                var allocationList = allocationGroup.ToList();
                var count = allocationList.Count();
    
                using (ExcelRange Rng = wsSheet1.Cells["A" + rowNumber + ":G" + (count + rowNumber)])
                {
                    ExcelTableCollection tblcollection = wsSheet1.Tables;
                    ExcelTable table = tblcollection.Add(Rng, "tblAllocations" + tableIndex);
    
                    //Set Columns position & name  
                    table.Columns[0].Name = "Manager Strategy";
                    table.Columns[1].Name = "Fund";
                    table.Columns[2].Name = "Portfolio";
                    table.Columns[3].Name = "As Of";
                    table.Columns[4].Name = "EMV (USD)";
                    table.Columns[5].Name = "Percent";
                    table.Columns[6].Name = "Allocations";
    
                    wsSheet1.Column(1).Width = 45;
                    wsSheet1.Column(2).Width = 45;
                    wsSheet1.Column(3).Width = 55;
                    wsSheet1.Column(4).Width = 15;
                    wsSheet1.Column(5).Width = 25;
                    wsSheet1.Column(6).Width = 20;
                    wsSheet1.Column(7).Width = 20;
    
                    table.ShowHeader = showHeader;
                    table.ShowFilter = showFilter;
                    table.ShowTotal = showTotals;
                    //Add TotalsRowFormula into Excel table Columns  
                    table.Columns[0].TotalsRowLabel = "Total Rows";
                    table.Columns[4].TotalsRowFormula = "SUBTOTAL(109,[EMV (USD)])";
                    table.Columns[5].TotalsRowFormula = "SUBTOTAL(109,[Percent])";
                    table.Columns[6].TotalsRowFormula = "SUBTOTAL(109, [Allocations])";
    
                    table.TableStyle = TableStyles.Dark10;
                }
    
                //Account for the table header
                rowNumber += rowAdderForHeader; 
    
                foreach (var ac in allocationGroup)
                {
                    wsSheet1.Cells["A" + rowNumber].Value = ac.MANAGER_STRATEGY_NAME;
                    wsSheet1.Cells["B" + rowNumber].Value = ac.MANAGER_FUND_NAME;
                    wsSheet1.Cells["C" + rowNumber].Value = ac.PRODUCT_NAME;
                    wsSheet1.Cells["D" + rowNumber].Value = ac.EVAL_DATE.ToString("dd MMM, yyyy");
                    wsSheet1.Cells["E" + rowNumber].Value = ac.UsdEmv;
                    wsSheet1.Cells["F" + rowNumber].Value = Math.Round(ac.GroupPercent, 2);
                    wsSheet1.Cells["G" + rowNumber].Value = Math.Round(ac.WEIGHT_WITH_EQ, 2);
                    rowNumber++;
                }
                //Account for the table footer
                rowNumber += rowAdderForFooter;
            }
        }
    }
    public class FIRMWIDE_MANAGER_ALLOCATION
    {
    	public FIRMWIDE_MANAGER_ALLOCATION(string name, Random rnd)
    	{
    		Name = name;
    		MANAGER_STRATEGY_NAME = "strategy name";
    		MANAGER_FUND_NAME = "fund name";
    		PRODUCT_NAME = "product name";
    		EVAL_DATE = DateTime.Now;
    		UsdEmv = (decimal)rnd.NextDouble() * 100000000;
    		GroupPercent = (decimal)rnd.NextDouble() * 100;
    		WEIGHT_WITH_EQ = 0;
    	}
    
    	public string Name { get; set; }
    	public string MANAGER_STRATEGY_NAME { get; set; }
    	public string MANAGER_FUND_NAME { get; set; }
    	public string PRODUCT_NAME { get; set; }
    	public DateTime EVAL_DATE { get; set; }
    	public decimal UsdEmv { get; set; }
    	public decimal GroupPercent { get; set; }
    	public decimal WEIGHT_WITH_EQ { get; set; }
    }
    public class DataGenerator
    {
    	public static Random rnd = new Random();
    	
    	public ILookup<string, FIRMWIDE_MANAGER_ALLOCATION> Generate()
    	{
    		var data = new List<FIRMWIDE_MANAGER_ALLOCATION>();
    		var itemCount = rnd.Next(1, 100);
    		
    		for (var itemIndex = 0; itemIndex < itemCount; itemIndex++)
    		{
    			var name = Path.GetRandomFileName();
    			data.AddRange(GenerateItems(name));
    		}
    		return data.ToLookup(d => d.Name, d => d); 
    	}
    	
    	private IEnumerable<FIRMWIDE_MANAGER_ALLOCATION> GenerateItems(string name)
    	{
    		var itemCount = rnd.Next(1,100);
    		var items = new List<FIRMWIDE_MANAGER_ALLOCATION>();
    		
    		for (var itemIndex = 0; itemIndex < itemCount; itemIndex++)
    		{
    			items.Add(new FIRMWIDE_MANAGER_ALLOCATION(name, rnd));
    		}
    		return items;
    	}
    }
