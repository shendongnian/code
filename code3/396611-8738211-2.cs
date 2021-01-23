    class ArticleInfo
    {
        private string html;
        public ArticleInfo (string html) 
        {
            this.html = html;
            URL = //code to extract and assign Url from html
            PostContent = //code to extract content from html
            PostImage = //code to extract Image from html
            PostDate = //code to extract date from html
        }
        public string URL { get; private set; }
        public string PostContent { get; private set; }
        public string PostImage { get; private set; }
        public DateTime PostDate { get; private set; }
        public string Contr { get { return html; } }
    }
