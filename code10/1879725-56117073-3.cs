    return sites.GroupBy(x => x.RouteId)
                .SelectMany(x =>
                {
                    var groupedSites = new List<List<Site>>();
                    var aggList = new List<Site>();
                    foreach (var item in x)
                    {
                        if (aggList.Count == 0 || aggList.Any(y => y.EndMilepost == item.StartMilepost))
                        {
                            aggList.Add(item);
                            continue;
                        }
    
                        var groupMatchIndex = groupedSites.FindIndex(y => y.Any(z => z.EndMilepost == item.StartMilepost));
                        if (groupMatchIndex > -1)
                        {
                            var el = groupedSites.ElementAt(groupMatchIndex);
                            el.Add(item);
                            groupedSites[groupMatchIndex] = el;
                            continue;
                        }
    
                        groupedSites.Add(aggList);
                        aggList = new List<Site>();
                        aggList.Add(item);
                    }
    
                    groupedSites.Add(aggList);
                    return groupedSites;
                });
