	public static void Main()
	{
		var guid = Guid.NewGuid();
		List<CategoryListViewModel> list = new List<CategoryListViewModel>
		                                   	{
		                                   		new CategoryListViewModel
		                                   			{ CategoryId = guid, CategoryName = "Hi", Selected = false }
		                                   	};
		list.Where(cvm => cvm.CategoryId == guid).Single().Selected = true;
		Console.WriteLine(list[0].Selected);
	}
	public class CategoryListViewModel
	{
		public Guid CategoryId { get; set; }
		public string CategoryName { get; set; }
		public bool Selected { get; set; }
	}
