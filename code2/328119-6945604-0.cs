    public ApplicationViewModel SelectedApplication
        {
            get
            {
                if (InvokeRequired)
                {
                    BeginInvoke(() => { return SelectedApplication(); });
                }
    
                return _applicationsCombobox.SelectedItem as ApplicationViewModel;
            }
        }
