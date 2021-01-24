    public class FilterModel
	{
		public string var1{ get; set; }
		public string var2{ get; set; }
		public string var3{ get; set; }
		public string var4{ get; set; }
		public List<string> var5{ get; set; }
	}
        [HttpPost]
		public IActionResult Report_2(FilterModel filter)
		{
			FilterLogic filterLogic = new FilterLogic(_context);
			var result = filterLogic.GetResult(filter);
			return View();	
		}
