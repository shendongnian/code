    private ObservableCollection<WorkspaceViewModel> _workspaces;
    
    public ObservableCollection<WorkspaceViewModel> Workspaces
    {
        get
        {
            if (_workspaces == null)
            {
                _workspaces = new ObservableCollection<WorkspaceViewModel>();
            }
            return _workspaces;
        }
    }
