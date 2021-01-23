		public static IEnumerable<T> IncludeUnsaved<T>(this ObjectSet<T> set) where T : class
		{
			var addedObjects = set.Context.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Added);
			var equalObjects = addedObjects.OfType<T>();
			
			return equalObjects.Concat(set);
		}
