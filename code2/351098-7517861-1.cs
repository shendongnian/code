    private List<Option> options;
    private List<Option> Options
    {
        get 
        {
            if (options== null)
            {
                options = new List<Option>();
                // Load Options - For example:
                options.Add(new Option { Description = "Option A", IsChecked = false });
                options.Add(new Option { Description = "Option B" });
                options.Add(new Option { Description = "Option C", IsChecked = true});
            }
            return options; 
        }
    }
