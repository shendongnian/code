    result.Error.Where(e => e.ErrorDetails != null && e.ErrorDetails.Any())
    			.SelectMany(e => e.ErrorDetails.Where(ed => ed.Tags != null && ed.Tags.Any())
    			.SelectMany(ed => ed.Tags)).ToList()
    			.ForEach(tagsItem =>
    				foreach (KeyValuePair<string, List<string>> categoryItem in _categories.Value)
    				{
    					if (categoryItem.Value.Contains(tagsItem))
    					{
    						errorDetailsItem.Categories.Add(categoryItem.Key);
    					}
    				}
    			);
