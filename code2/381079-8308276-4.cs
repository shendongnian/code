    ...
    .Select(cnt => 
        new ConcType{ 
            Title = cnt.Title, 
            TitleUrl = cnt.TitleUrl, 
            ContentId = cnt.ContentId, 
            TypeContent = cnt.TypeContent,  
            Summary = cnt.Summary })
    ...
