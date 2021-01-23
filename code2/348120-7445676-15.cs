    public CustomCollection<T> Collection
	{
	    get
		{
			return this.wrappedCollection;
		}
	}
	private CustomCollection<T> wrappedCollection; // Initialise this in the constructor, or possibly in the Collection getter
    private List<T> collection = new List<T>();
