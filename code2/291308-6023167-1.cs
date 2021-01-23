    public IEnumerable<News> TodaysNews
    {
        get
        {
            return this.News.Where(x => x.PublishedDate == DateTime.Now.Date);
        }
    }
