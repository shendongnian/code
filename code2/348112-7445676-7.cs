    public CustomCollection<T> Collection
	{
	    get
		{
		    if (this.wrappedCollection == null)
			{
			    this.wrappedCollection = new CustomCollection<T>(this.collection);
			}
			return this.wrappedCollection;
		}
	}
	private CustomCollection<T> wrappedCollection;
    private List<T> collection = new List<T>();
