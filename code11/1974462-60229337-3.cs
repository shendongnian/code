    var q = from channel in mongoDBCollection.AsQueryable()
            from episode in channel.Episodes
            select new Episode()
            {
                Id = episode.Id,
                Name = episode.Name,
                Tracks = episode.Tracks.Where(x => x.Id == trackId)
            };
    var query = q.Where(x => x.Tracks.Any());
    var result = query.ToList();
