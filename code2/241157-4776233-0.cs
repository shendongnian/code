    	var result = this.DataList
				.GroupBy(data => data.Week)
				.Select(data=>
				{
					return data.GroupBy(item => item.Name)
						.Select(item => new { Name = item.Key, SumPoints = item.Sum(v => v.Points) })
						.OrderBy(item => item.SumPoints)
						.FirstOrDefault();
				})
				.GroupBy(_=>_.Name)
				.ToDictionary(_=>_.Key, _=>_.Count());
