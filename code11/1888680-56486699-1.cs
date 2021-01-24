	headers.Select((name, index) => new { name, index })
		.AsParallel()
		.ForAll
		(
			header =>
			{
				switch (header.name)
				{
					case "First":
						firstColumn = header.index;
						break;
					case "Second":
						secondColumn = header.index;
						break;
				}
			}
		);
