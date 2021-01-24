    var q = from channel in mongoDBCollection.AsQueryable()
            where channel.Id == "5e4606e6ae7b090688671416"
            from episode in channel.Episodes
            select new 
            {
                Channel = new Channel(){ Id = channel.Id, Name = channel.Name},
                Episode = new Episode()
                {
                    Id = episode.Id,
                    Name = episode.Name,
                    Tracks = episode.Tracks.Where(x => x.Id == trackId)
                }
            };
    var query = q.Where(x => x.Episode.Tracks.Any());
    var result = query.ToList();
