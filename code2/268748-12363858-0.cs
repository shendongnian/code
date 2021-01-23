	public static class ObjectExtensions
	{
		/// <summary>
		/// Simplifies correctly calculating hash codes based upon
		/// Jon Skeet's answer here
		/// http://stackoverflow.com/a/263416
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="memberThunks">Thunks that return all the members upon which
		/// the hash code should depend.</param>
		/// <returns></returns>
		public static int CalculateHashCode(this object obj, params Func<object>[] memberThunks)
		{
		    // Overflow is okay; just wrap around
		    unchecked
		    {
		        int hash = 5;
		        foreach (var member in memberThunks)
		            hash = hash * 29 + member().GetHashCode();
		        return hash;
		    }
		}
	}
