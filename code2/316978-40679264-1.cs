    public ICommand ToolTipHoverRefreshCommand => new DelegateCommand(() =>
    {
        this.OnPropertyChanged(this.ToolTip);
    });  
    public string ToolTip
    {
        get
        {
            return DateTime.Now.ToString();
        }
        set
        {
            this.OnPropertyChanged(nameof(this.ToolTip));
        }
    }
