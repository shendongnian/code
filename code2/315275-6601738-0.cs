    	public IEnumerable<Combination> GetCombinations(Variation[] variations, int variationIndex, IEnumerable<VariationPosition> aggregatedPositions)
		{
			// We should choose one position from every variation, 
			// so we couldn't produce combination till we reach end of array. 
			if (variationIndex < variations.Length)
			{
				// Pick current variation.  
				var currentVariation = variations[variationIndex];
				// Every variation has list of possible positions (Color could be Green, Redm, Blue, etc.).
				// So we should walk through all the positions 
				foreach (var val in currentVariation.Positions)
				{
					// Current position. Variation's name will be used during creating result Combination.
					var position = new VariationPosition()
					{
						Name = currentVariation.Name,
						Value = val
					};
					// Add position to already aggregated on upper levels of recursion positions.
					var newPositions = aggregatedPositions.Concat(Enumerable.Repeat(position, 1));
					// So we picked some variation position 
					// Let's go deeper.
					var combinations = this.GetCombinations(variations, variationIndex + 1, newPositions );
					// This piece of code allows us return combinations in iterator fashion.
					foreach (var combination in combinations)
					{
						yield return combination;
					}
				}
			}
			else
			{
				// We reached end of variations array 
				// I mean we have one position of every variation. 
				// We concatenate name of positions in order to create string like "Red-S-34"
				var name = aggregatedPositions.Aggregate("", (res, v) => res += v.Name);
				// This code is a little bit naive, I'm too lazy to create proper infrastructure,
 				// But its mission is to create content for property Value of your ebayVariations item. 
				var value = aggregatedPositions
					.Select(v => new { Name = v.Name, Values = new[] { new { Value = v.Value } } })
					.ToArray();
				// And we return completed combination.
				yield return new Combination()
				{
					Name = name,
					Value = value,
				};
			}
		}
