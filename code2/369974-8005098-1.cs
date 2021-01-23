		public void FilterByHasDate(this Collection<IDated> input)
		{
			var itemsToRemove = input.Where(x => x.Date.HasValue);
			foreach (var itemToRemove in itemsToRemove)
			{
				input.Remove(itemToRemove);
			}
		}
