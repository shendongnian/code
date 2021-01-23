    using System;
    using System.IO;
    using System.Xml.Serialization;
    namespace xmlTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var articles = new Articles();
                articles.ArticleArray = new ArticlesArticle[2]
                {
                    new ArticlesArticle()
                        {
                            Guid = Guid.NewGuid(),
                            Order = 1,
                            Type = "deal_abstract",
                            Title = "Abu Dhabi...",
                            Summary = "Abu Dhabi...",
                            ArticleDate = new DateTime(2011,2,24)
                        },
                    new ArticlesArticle()
                        {
                            Guid = Guid.NewGuid(),
                            Order = 2,
                            Type = "deal_abstract",
                            Title = "Abu Dhabi...",
                            Summary = "China...",
                            ArticleDate = new DateTime(2011,2,23)
                        },
                };
                var sw = new StringWriter();
                var xmlSer = new XmlSerializer(typeof (Articles));
                var noNamespaces = new XmlSerializerNamespaces();
                noNamespaces.Add("", ""); 
                xmlSer.Serialize(sw, articles,noNamespaces);
                Console.WriteLine(sw.ToString());
            }
        }
        [XmlRoot(ElementName = "articles", Namespace = "", IsNullable = false)]
        public class Articles
        {
            [XmlElement("article")]
            public ArticlesArticle[] ArticleArray { get; set; }
        }
        public class ArticlesArticle
        {
            [XmlElement("guid")]
            public Guid Guid { get; set; }
            [XmlElement("order")]
            public int Order { get; set; }
            [XmlElement("type")]
            public string Type { get; set; }
            [XmlElement("textType")]
            public string TextType { get; set; }
            [XmlElement("id")]
            public int Id { get; set; }
            [XmlElement("title")]
            public string Title { get; set; }
            [XmlElement("summary")]
            public string Summary { get; set; }
            [XmlElement("readmore")]
            public string Readmore { get; set; }
            [XmlElement("fileName")]
            public string FileName { get; set; }
            [XmlElement("articleDate")]
            public DateTime ArticleDate { get; set; }
            [XmlElement("articleDateType")]
            public string ArticleDateType { get; set; }
        }
    }
