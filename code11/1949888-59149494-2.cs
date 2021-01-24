    [BindProperty]
    public string selectedFilter { get; set; }
    public void  OnPost()
        {
            var data = selectedFilter;
        }
