        foreach (var path in context.Document.Paths)
        {
            foreach (var item in path.Value.Values)
            {
                item.Description = item.Description.Replace("&amp;", "&");
            }
        }
