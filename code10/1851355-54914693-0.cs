		var test = propertiesOfInterest
			.SelectMany(propertyInfo => phases
				.Select(phase => new
				{
					phase.Direction,
					propertyInfo.Name,
					Value = (double)propertyInfo.GetValue(phase)
				}))
			.GroupBy(o => new BmkKey { Direction = o.Direction, DetailType = o.Name })
			.ToDictionary(grp => grp.Key, grp => grp.Select(x => x.Value));
