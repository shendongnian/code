	List<Participant_New> newModelCollection = participantCollection
                        .GroupBy(x => new {Id = x.Id, Name = x.Name})
						.Select(g => new Participant_New
						{
							Id = g.Key.Id,
							Name = g.Key.Name,
							Address = g.Select(a => new Address{Name = a.Address}).ToList()
						}).ToList();
