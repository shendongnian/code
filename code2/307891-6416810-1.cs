	//outside of this code is refered to your code.
	//Returning IEnumerable could be used outside this scope if AppDbContext is ensured no disposing
	public IEnumerable<Post> GetIEnumerableWithoutActualData()
	{
		return context.Posts;
	}
	//Even if AppDbContext is disposed, IEnumerable could be used.
	public IEnumerable<Post> GetIEnumerableWithActualData()
	{
		return context.Posts.ToList();
	}
