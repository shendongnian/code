	public class ExportOrderAttribute : Attribute
	{
		public ExportOrderAttribute(int order)
		{
			Order = order;
		}
		public int Order { get; set; }
	}
	public class TestObject
	{
		/// <summary>
		/// Best to make static to avoid repeat calls to Reflections (if possible).
		/// </summary>
		public static MemberInfo[] MemberSortInfo { get; } = typeof(TestObject)
			.GetProperties()
			.Select(pi => new
			{
				Property = pi,
				Attribute = (ExportOrderAttribute) Attribute.GetCustomAttribute(
					pi
					, typeof(ExportOrderAttribute)
					, true
				)
			})
			.OrderBy(a => a.Attribute?.Order ?? -1)
			.Select(a => a.Property)
			.Cast<MemberInfo>()
			.ToArray();
		[ExportOrder(4)]
		public int IntCol1 { get; set; }
	  
		[ExportOrder(3)]
		public int IntCol2 { get; set; }
	  
		[ExportOrder(2)]
		public string StringCol { get; set; }
		[ExportOrder(1)]
		public DateTime DateCol { get; set; }
	 
		[ExportOrder(0)]
		public int IntCol3 { get; set; }
	}
	[TestMethod]
	public void Sort_Column_Output()
	{
		//https://stackoverflow.com/questions/58177582/how-to-sort-columns-when-serializing-the-properties-of-a-class-when-used-with-ep
		var rnd = new Random();
		var testObjects = Enumerable
			.Range(0, 10)
			.Select(i => new TestObject
			{
				IntCol1 = i,
				IntCol2 = i * 10,
				StringCol = Path.GetRandomFileName(),
				DateCol = DateTime.Now.AddDays(rnd.Next(0, 100)),
				IntCol3 = rnd.Next(100, 10000)
			})
			.ToList();
		
		var fi = new FileInfo("c:\\temp\\Sort_Column_Output.xlsx");
		if (fi.Exists)
			fi.Delete();
		using (var pck = new ExcelPackage(fi))
		{
			var worksheet = pck.Workbook.Worksheets.Add("Sheet1");
			worksheet.Cells.LoadFromCollection(
				testObjects
				, true
				, TableStyles.None
				, BindingFlags.Instance | BindingFlags.Public
				, TestObject.MemberSortInfo  //CONTROLS THE SORTING
			);
			pck.Save();
		}
	}
