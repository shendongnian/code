		public static void ForceCreationOfSingletons(this IWindsorContainer container)
		{
			var singletons =
				container.Kernel.GetAssignableHandlers(typeof (object))
				         .Where(h => h.ComponentModel.LifestyleType == LifestyleType.Singleton);
			foreach (var handler in singletons)
			{
				container.Resolve(handler.ComponentModel.Service);
			}
		}
        // usage container.ForceCreationOfSingletons();
