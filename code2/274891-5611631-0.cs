    public IEnumerable<Title> GetTitles()
    {
        return titleRepository
            .GetAll()
            .Where(x => x.Active)
            .OrderBy(x => x.Name)
        };
    }
