    public ReadOnlyCollection<T> Collection
	{
	    get
		{
		    return new ReadOnlyCollection<T>(this.collection);
		}
	}
    private List<T> collection = new List<T>();
	
	public AddItem(T item);
