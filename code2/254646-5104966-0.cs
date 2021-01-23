    var queryTitle = (from content in context.CmsContents
                     select new
                     {
                         Title = content.Title, // String
                         ContentId = content.ContentId.ToString() // Int
                     }).ToArray();
