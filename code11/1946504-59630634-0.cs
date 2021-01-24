	public interface IExample<out TBase>
	{
		// no Where, Count, or FirstOrDefault methods that accept Expression defined here
		
        // This is a lazy loading method and doesn't execute the query
		IQueryable<TBase> GetAll(ApplicationUser user);
	}
	
	public static class ExtensionMethods
	{
		public static IQueryable<TBase> Where<TBase>(
			this IExample<TBase> repository,
			ApplicationUser user,
			Expression<Func<TBase, bool>> predicate)
        {
            return repository.GetAll(user).Where(predicate);
        }
		
		public static int Count<TBase>(
			this IExample<TBase> repository,
			ApplicationUser user,
			Expression<Func<TBase, bool>> predicate)
		{
			return repository.GetAll(user).Count(predicate);
		}
		
		public static TBase FirstOrDefault<TBase>(
			this IExample<TBase> repository,
			ApplicationUser user,
			Expression<Func<TBase, bool>> predicate)
		{
			return repository.GetAll(user).FirstOrDefault(predicate);
		}
	}
	
	
