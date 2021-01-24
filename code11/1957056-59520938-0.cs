    var result = (from e in entities
					  join j in jobs on e.EntityId equals j.CustomerId
					  where e.Active && e.EntityTypeId == 1
					  select new 
					  {
						  e.EntityId, 
						  e.Name,
						  j.JobId
					  }).GroupBy( p => new { p.EntityId, p.Name })
						.Select(g => new 
									{
										EntityId = g.First().EntityId, 
										Name = g.First().Name,
										JobCount = g.Count()  
									})
						.OrderBy(p => p.Name);
