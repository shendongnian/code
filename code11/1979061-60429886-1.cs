    private List<string> m_items;
    public List<string> Items
    {
    	get => m_items;
    	set
    	{
    		m_items = value;
    		OnPropertyChanged(nameof(Items));
    	}
    }
