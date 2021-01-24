    public BindableListView(ListViewCachingStrategy cachingStrategy)
            : base(cachingStrategy)
    {
        Init();
    }
    public BindableListView()
            : base()
    {
        Init();
    }
    private void Init()
    {
        ItemTapped += OnItemTapped;
        ItemAppearing += OnItemAppearing;
        ItemSelected += OnItemSelected;
        ...
    }
