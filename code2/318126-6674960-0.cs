    private BindingListCollectionView _view;
    public BindingListCollectionView MyView 
    {
        get { return this._view; }
        protected set
        {
            this._view = value;
            this.NotifyPropertyChanged(() => this.MyView);
        }
    }
