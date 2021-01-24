	public List<ITabUserControl> UserControls { get; set; }
        public ShellViewModel()
        {
            UserControls = new List<ITabUserControl>();
            UserControls.Add(new PageAViewModel());
            UserControls.Add(new PageBViewModel());
        }
