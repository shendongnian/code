    private ObservableCollection<WorkspaceViewModel> _workspaces;
    
    public ObservableCollection<WorkspaceViewModel> Workspaces
    {
        get
        {
            if (_workspaces == null)
            {
                _workspaces = new ObservableCollection<WorkspaceViewModel>();
                _workspaces.CollectionChanged += this.OnWorkspacesChanged;
            }
            return _workspaces;
        }
    }
