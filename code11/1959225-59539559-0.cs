    var RouteList = from site in Sites
                        orderby site.Community.Name ascending
                        where site.Season.SeasonYear == 2019 && site.Yard.YardID == 1 && site.SiteType.SiteTypeDescription.Equals("A")
                        select new Status
                        {
                            Pin = site.Pin,
                            Community = site.Community.Name,
    
                             Cycle1 = ((from sbm in SBMs where sbm.CrewSite.SiteID == site.SiteID select new Cycle { Date = DbFunctions.TruncateTime(sbm.CrewSite.Crew) }).OrderBy(x => x.Date).FirstOrDefault()).Equals(null)
                                 ? (DateTime?)null : ((from sbm in SBMs where sbm.CrewSite.SiteID == site.SiteID select new Cycle { Date = DbFunctions.TruncateTime(sbm.CrewSite.Crew)}).OrderBy(x => x.Date).FirstOrDefault()).Date
    
    ...
