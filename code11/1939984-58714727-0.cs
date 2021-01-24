	[NotMapped]
	public ICollection<B> Bs
	{
		get
		{
			return ABs.Select(item => item.B).ToList();
		}
	}
