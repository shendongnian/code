    public TestSelectModel()
    {
        _searchoptions = new List<SelectListItem>();
        _searchoptions.Add(new SelectListItem() { Text = "By Email", Value = "1", Selected = true });
        _searchoptions.Add(new SelectListItem() { Text = "By Request Name", Value = "2", Selected = false });
    }
    public void OnGet()
    {
        if(BoundSearchField is null)
        {
            BoundSearchField = "1";
        }
        SearchOptions = new SelectList(_searchoptions, "Value", "Text", BoundSearchField);
    }
