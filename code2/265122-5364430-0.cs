        private string content;
        [XmlText]
        public string Content
        {
            get { return content; }
            set { content = XElement.Parse(value).Value; }
        }
