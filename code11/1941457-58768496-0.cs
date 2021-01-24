    var result = inputs.GroupBy(x => x.Name)
			.Select(g => new {
				Name = g.Key,
				Rows = g.GroupBy(x => new {x.Customer, x.Number})
					.Select(g2 => new{
						Number = g2.Key.Number,
						Customer = g2.Key.Customer,
						Details = g2.GroupBy(x => new {x.FileId,x.FileNumber})
									.Select(g3 => new {Amt = g3.Sum(x => x.Amt), g2.Key.Number, g3.Key.FileId, g3.Key.FileNumber})
					})
			});
