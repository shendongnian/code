	public List<ITabUserControl> UserControls { get; set; }
        public ShellViewModel()
        {
            UserControls = new List<ITabUserControl>();
            UserControls.Add(new MasterTechnicianViewModel());
            UserControls.Add(new ServicesViewModel());
        }
