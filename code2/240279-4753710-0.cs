    Dictionary<TabPage, HashSet<Control>> _tabControls 
                               = new Dictionary<TabPage, HashSet<Control>>();
    
        public OptionsForm()
        {   
            InitializeComponent();
            RegisterToValidationEvents();
        }
    
        private void RegisterToValidationEvents()
        {
            foreach (TabPage tab in this.OptionTabs.TabPages)
            {
                var tabControlList = new HashSet<Control>();
                _tabControls[tab] = tabControlList;
                foreach (Control control in tab.Controls)
                {
                    var capturedControl = control; //this is necessary
                    control.Validating += (sender, e) =>
                        tabControlList.Add(capturedControl);
                    control.Validated += (sender, e) =>
                        tabControlList.Remove(capturedControl);
                }
            }
        }
    
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                _settings.Save();
                this.Close();
            }
            else
            {
                var unvalidatedTabs = _tabControls.Where(kvp => kvp.Value.Count != 0)
                                                  .Select(kvp => kvp.Key);
                TabPage firstUnvalidated = unvalidatedTabs.FirstOrDefault();
                if (firstUnvalidated != null && 
                    !unvalidatedTabs.Contains(OptionTabs.SelectedTab))
                        OptionTabs.SelectedTab = firstUnvalidated;
            }
        }
