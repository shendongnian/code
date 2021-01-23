    #region GoogleNewsSiteMap Class
    [XmlRoot("urlset", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    public class GoogleNewsSiteMap
    {
        const string _newsSiteMapSchema = "http://www.google.com/schemas/sitemap-news/0.9";
        const string _newsSiteMapPrefix = "n";
        public void Create(string loc, string prioity, string language, string name, string genres, string publicationDate, string title)
        {
            NewsSiteMap news = new NewsSiteMap();
            news.Loc = loc;
            news.Priority = prioity;
            news.NewsSiteMapNews.Publication.Language = language;
            news.NewsSiteMapNews.Publication.Name = name;
            news.NewsSiteMapNews.Genres = genres;
            news.NewsSiteMapNews.PublicationDate = publicationDate;
            news.NewsSiteMapNews.Title = title;
            List.Add(news);
        }
        public string GetXMLString()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.Encoding = new UTF8Encoding(false);
            using (StringWriter str = new StringWriter())
            using (XmlWriter writer = XmlWriter.Create(str, settings))
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add(_newsSiteMapPrefix, _newsSiteMapSchema);
                XmlSerializer xser = new XmlSerializer(typeof(GoogleNewsSiteMap));
                xser.Serialize(writer, this, ns);
                return str.ToString();
            }
        }
        private List<NewsSiteMap> _list = null;
        [XmlElement("url")]
        public List<NewsSiteMap> List
        {
            get
            {
                if (_list == null)
                {
                    _list = new List<NewsSiteMap>();
                }
                return _list;
            }
        }
        #region NewsSiteMap Class
        public class NewsSiteMap
        {
            private string _loc = string.Empty;
            private string _priority = string.Empty;
            private NewsSiteMap_News _newsSiteMap_News = null;
            [XmlElement("loc")]
            public string Loc
            {
                get { return _loc; } set { _loc = value; }
            }
            [XmlElement("priority")]
            public string Priority
            {
                get { return _priority; }  set { _priority = value; }
            }
            
            [XmlElement("news", Namespace = _newsSiteMapSchema)]
            public NewsSiteMap_News NewsSiteMapNews
            {
                get {
                    if (_newsSiteMap_News == null)
                    {
                        _newsSiteMap_News = new NewsSiteMap_News();
                    }
                    return _newsSiteMap_News; 
                }
                set { _newsSiteMap_News = value; }
            }
            #region NewsSiteMap_News Class
            public class NewsSiteMap_News
            {
                private NewsSiteMap_Publication _publication = null;
                private string _genres = string.Empty;
                private string _publicationDate = string.Empty;
                private string _title = string.Empty;
                private string _keywords = string.Empty;
                private string _stockTickers = string.Empty;
                [XmlElement("publication", Namespace = _newsSiteMapSchema)]
                public NewsSiteMap_Publication Publication
                {
                    get
                    {
                        if (_publication == null)
                        {
                            _publication = new NewsSiteMap_Publication();
                        }
                        return _publication;
                    }
                    set { _publication = value; }
                }
                [XmlElement("genres")]
                public string Genres
                {
                    get { return _genres; }
                    set { _genres = value; }
                }
                [XmlElement("publication_date")]
                public string PublicationDate
                {
                    get
                    {
                        try
                        {
                            return string.Format("{0:s}", Convert.ToDateTime(_publicationDate)) + string.Format("{0:zzz}", Convert.ToDateTime(_publicationDate));
                        }
                        catch (Exception ex)
                        {
                            return _publicationDate;
                        }
                    }
                    set { _publicationDate = value; }
                }
                public string Title
                {
                    set { _title = value; }
                }
                [XmlElement("title")]
                public XmlCDataSection CTitle
                {
                    get
                    {
                        XmlDocument doc = new XmlDocument();
                        return doc.CreateCDataSection(_title);
                    }
                    set { _title = value.Value; }
                }
                [XmlElement("keywords")]
                public string Keywords
                {
                    get { return _keywords; }  set { _keywords = value; }
                }
                [XmlElement("stock_tickers")]
                public string StockTickers
                {
                    get { return _stockTickers; }  set { _stockTickers = value; }
                }
                #region NewsSiteMap_Publication Class
                public class NewsSiteMap_Publication
                {
                    private string _name = string.Empty;
                    private string _language = string.Empty;
                    [XmlElement("name")]
                    public string Name
                    {
                        get { return _name; }
                        set { _name = value; }
                    }
                    [XmlElement("language")]
                    public string Language
                    {
                        get { return _language; }
                        set { _language = value; }
                    }
                }
                #endregion NewsSiteMap_Publication Class
            }
            #endregion NewsSiteMap_News Class
        }
        #endregion NewsSiteMap Class
    }
    #endregion GoogleNewsSiteMap Class
