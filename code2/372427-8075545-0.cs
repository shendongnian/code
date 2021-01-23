    var entities = new TestEntities();
            var cycleId = 1;
            var filteredDistributions = entities.Territories
                                        .Join(entities.Distributions.Where(d => d.CycleId == cycleId),
                                              territory => territory.Id,
                                              distribution => distribution.Territory.Id,
                                              (territory, distribution) => distribution);
