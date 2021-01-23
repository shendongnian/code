            var itemsQuery = queryOver.Clone()
                .Where(a => a.channelID != null)
                .OrderBy(Projections.Max<ChannelFind>(a => a.liveStartTime));
           var sortedQuery = Sort(itemsQuery, sort)
                .Select(Projections.GroupProperty(Projections.Property<ChannelFind>(a => a.channelID)))
                .Skip(index ?? 0)
                .Take(itemsPerPage ?? 20);
