    int tagId = ...;
    var query = from a in context.Articles
                where a.Tags.Any(t => t.TagId == tagId) && a.Published 
                select new 
                   {
                       a.ArticleId,
                       a.Title,
                       a.Tooltip,
                       a.UriTitle,
                       a.SubTitle,
                       a.Published,
                       tagId // I'm not sure if this will work but let give it a try  
                   };
