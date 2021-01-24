C#
var results = session.Query<Communication>()
		.Where(c => c == session.Query<Communication>()
							.Where(cs => cs.Customer == c.Customer)
							.OrderByDescending(cs => cs.Message.CreatedOn)
							.First()
		).ToList();
