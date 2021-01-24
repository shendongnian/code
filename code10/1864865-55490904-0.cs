    //my test class for the 'flat' folder structure
    public class Item
	{
		public string Id { get; set; }
		public string ParentId { get; set; }
		public string title { get; set; }
		public List<Item> subs { get; set; }
		public Item()
		{
			this.Id = "";
			this.ParentId = "";
			this.title = "";
			this.subs = new List<Item>();
		}
	}
    //example using MVC controller
    public class YourController : Controller
	{
        //var to hold all the 'flat' data
	    private List<Item> fulllist = new List<Item>();
	
        //recursive method to loop through the flat list
		public List<Item> GetChildren(string parentId)
		{
			List<Item> result = new List<Item>();
			foreach (Item child in fulllist.Where(n=>n.ParentId == parentId))
			{
				child.subs = GetChildren(child.Id);
				result.Add(child);
			}
			return result;
		}
		
		[HttpGet]
		public ActionResult Index()
		{
			//populate the flat list with test data (multi-level)
			fulllist.Add(new Item()
			{Id = "1", ParentId = "", title = "main 1"});
			fulllist.Add(new Item()
			{Id = "2", ParentId = "", title = "main 2"});
			fulllist.Add(new Item()
			{Id = "3", ParentId = "1", title = "main 1 - sub 1"});
			fulllist.Add(new Item()
			{Id = "4", ParentId = "", title = "main 3"});
			fulllist.Add(new Item()
			{Id = "5", ParentId = "4", title = "main 3 - sub 1"});
			fulllist.Add(new Item()
			{Id = "6", ParentId = "5", title = "main 3 - sub 1 - subsub 1"});
			fulllist.Add(new Item()
			{Id = "7", ParentId = "", title = "main 4"});
			fulllist.Add(new Item()
			{Id = "8", ParentId = "7", title = "main 4 - sub 1"});
			
            //get from the start of the tree
			var output = GetChildren("");
			
			return Json(output, JsonRequestBehavior.AllowGet);
		}
	}
