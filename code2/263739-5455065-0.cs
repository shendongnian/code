        static List<News> _topNews = null;
        static DateTime _topNewsLastUpdateTime = DateTime.MinValue;
        const int CacheTime = 5;  // In minutes
        public IList<News> GetTopNews()
        {
            if (_topNewsLastUpdateTime.AddMinutes(CacheTime) < DateTime.Now)
            {
                _topNews = GetList(TopNewsCount);
            }
            return _topNews;
        }
