    var noteData = repository.GetAll()
        .Select( x= > new {
            x.Id,
            AdditionalHashtags = x.AdditionalHashtags.Select(h => new HashtagDto { Id = h.Id, Text = h.Text }).ToList(),
            EntityAHashtag = new HashTagDto { Id = x.EntityA.Hashtag.Id, Text = x.EntityA.Hashtag.Text },
            EntityBHashtag = new HashTagDto { Id = x.EntityB.Hashtag.Id, Text = x.EntityB.Hashtag.Text },
        ).ToList();
