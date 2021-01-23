    tabMain.SelectedPageChanging += (s, e) =>
            { 
                tabMain.Enabled = false;
            };
            tabMain.SelectedPageChanged += (s, e) =>
            {
                tabMain.Enabled = true;                
            };
