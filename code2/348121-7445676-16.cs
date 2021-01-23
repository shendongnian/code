    public List<T> Collection
	{
	    get
		{
            return this.collection;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			this.collection = value;
		}
	}
	private List<T> collection = new List<T>();
