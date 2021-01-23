        private XmlNode _priceUrl;
        [XmlElement("price_url")]
        public XmlNode PriceUrl
        {
            get
            {
                return _priceUrl;
            }
            set
            {
                _priceUrl = value;
            }
        }
        [XmlIgnore]
        public string PriceUrlByString
        {
            get
            {
                // Retrieves the content of the encapsulated CDATA
                return _priceUrl.Value;
            }
            set
            {
                // Encapsulate in a CDATA XmlNode
                XmlDocument xmlDocument = new XmlDocument();
                this._priceUrl = xmlDocument.CreateCDataSection(value);
            }
        }
