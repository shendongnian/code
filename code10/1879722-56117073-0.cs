    return sites.GroupBy(x => x.RouteId)
    			.SelectMany(x =>
    			{
    				var groupedSites = new List<IEnumerable<Site>>();
    				var aggs = x.Aggregate(new List<Site>(), (contiguous, next) =>
    				{
    					if (contiguous.Count == 0 || contiguous.Any(y => y.EndMilepost == next.StartMilepost))
    					{
    						contiguous.Add(next);
    					}
    					else if (groupedSites.Any(y => y.Any(z => z.EndMilepost == next.StartMilepost)))
    					{
    						var groupMatchIndex = groupedSites.FindIndex(y => y.Any(z => z.EndMilepost == next.StartMilepost));
    						var el = groupedSites.ElementAt(groupMatchIndex).ToList();
    						el.Add(next);
    						groupedSites[groupMatchIndex] = el;
    					}
    					else
    					{
    						groupedSites.Add(contiguous);
    						contiguous = new List<Site>();
    						contiguous.Add(next);
    					}
    					return contiguous;
    				}, final => { groupedSites.Add(final); return final; });
    				return groupedSites;
    			});
