		public void FilterByHasDate(this Collection<IDated> input)
		{
			var itemsToRemove = input.Where(x => x.Date.HasValue).ToArray();
			foreach (var itemToRemove in itemsToRemove)
			{
				input.Remove(itemToRemove);
			}
		}
