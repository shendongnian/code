	private void LoadRootCategories()
	{
		Categories = new ObservableCollection<Category>(db.Categories.Where(x => x.ParentID == null));
		foreach (var item in Categories)
		{
			LoadSubCategories(item)
		}
	}
	private void LoadSubCategories(Category item)
	{
		item.SubCategories = new ObservableCollection<Category>(db.Categories.Where(x => x.ParentID == item.Id));
		
		foreach (var subitem in item.SubCategories)
		{
            // Recursive call
			LoadSubCategories(subitem);
		}
	}
