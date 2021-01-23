    //INPUT
	//theUniqueIDList1 = 2,3,6,9,11 
	//theUniqueIDList2 = 2,4,7,9,12
	//OUTPUT
	//2,3,4,6,7,9,11,12
	public class MyModel
	{
		public string TheData1 { get; set; }
		public string TheData2 { get; set; }
		public int UniqueID { get; set; }
	}
	
	public static void GroupByEx1()
		{
			// Create a list of Models.
			List<MyModel> theUniqueIDList1 =
				new List<MyModel>{ 	new MyModel { TheData1="Barley",	UniqueID=2 },
										new MyModel { TheData1="Boots",		UniqueID=3 },
										new MyModel { TheData1="Whiskers", 	UniqueID=6 },
										new MyModel { TheData1="Daisy", 	UniqueID=9 },
										new MyModel { TheData1="Preti", 	UniqueID=11 } };
			List<MyModel> theUniqueIDList2 =
				new List<MyModel>{ 	new MyModel { TheData1="Barley",	UniqueID=2 },
										new MyModel { TheData1="Henry",		UniqueID=4 },
										new MyModel { TheData1="Walsh", 	UniqueID=7 },
										new MyModel { TheData1="Daisy", 	UniqueID=9 },
										new MyModel { TheData1="Ugly", 	UniqueID=12 } };
			
			var concattedUniqueList = theUniqueIDList1.Concat(theUniqueIDList2)
				.OrderBy(f=>f.UniqueID).GroupBy(f=>f.UniqueID, f=>f).Select(g => g.First());
	
			foreach (var item in concattedUniqueList)
			{
				Console.WriteLine("UniqueId: {0}({1})", item.UniqueID, item.TheData1);
			}
		}
		
	void Main()
	{
		GroupByEx1();				
      	//2,3,4,6,7,9,11,12
	}
