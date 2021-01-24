    class NewsItemComparer : IComparer<NewsItem>
    {
        public static readonly IComparer<NewsItem> Default = new NewsItemComparer();
        private static readonly IComparer<DateTime> dateComparer = Comparer<DateTime>.Default;
        public int Compare(NewsItem x, NewItem y)
        {
            // TODO: decide what to do if x or y NULL: exception? first? last?
            return dateComparer.Compare(x.PublishedDate ?? x.CreatedDate,
                                        y.PublishedDate ?? y.CreatedDate);
        }
    }
