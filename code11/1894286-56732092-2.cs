	IEnumerable<MyClass> temp = records
		.GroupBy(x => x.Title)
		.Select(y => new MyClass
		{
			Title = y.Key,
			Columns = y.GroupBy(x => x.Column)
			.Select( c => new Column
			{
				Column_ = c.Key,
				Values = c.Select(v => new Value
				{
					Value_ = v.Value
				}).ToList()
			}).ToList()
		});
		
		temp.Dump();
