    public ApplicationViewModel SelectedApplication
    {
        get
        {
            if (this.InvokeRequired)
                return (ApplicationViewModel)this.Invoke(new Func<ApplicationViewModel>(() => this.SelectedApplication));
            else
                return _applicationsCombobox.SelectedItem as ApplicationViewModel;
        }
    }
