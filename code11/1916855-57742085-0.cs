    var posts = _appDataContext.Posts
        .Select(x => new
        {
            x.Id,
            x.Title,
            x.Body,
            Images = x.Images.Select(y => new
            {
                y.Id
            }).ToList() // <--
        });
