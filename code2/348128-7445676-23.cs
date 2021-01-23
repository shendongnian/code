    public MyClass()
    {
        this.wrappedCollection = new CustomCollection<T>(this.collection)
    }
    public CustomCollection<T> Collection
	{
	    get
		{
			return this.wrappedCollection;
		}
	}
	private CustomCollection<T> wrappedCollection;
    private List<T> collection = new List<T>();
