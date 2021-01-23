    var groupCriteria = DetachedCriteria.For<Groups>()
        .Add(Restrictions.Eq("this.Id", groupId))
        .Add(Restrictions.Eq("Group.Id", groupId)) 
        .AddOrder(Order.Asc("Group.PubDate"));
    return DetachedCriteria.For<EpisodeGroups>()
               .Add(Restrictions.Eq("this.Id", episodeId))
               .Add(Subqueries.PropertyIn("this.Groups", groupCriteria)
               .SetMaxResult(1);
