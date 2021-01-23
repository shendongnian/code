        var tags = this.Article.tags;
        if (!tags.IsLoaded && this.Article.EntityState != EntityState.Detached)
        {
            tags.Load();
        }
        return string.Join(" ", tags.Select(t => t.name).OrderBy(t => t))
