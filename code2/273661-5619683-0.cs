        [XmlAnyElement]
        public XmlElement[] AllElements
        {
            get
            {
                XmlElement[] value = new XmlElement[0];
                return value;
            }
            set
            {
                if (value != null)
                {
                    foreach (XmlElement e in value)
                    {
                        switch (e.Name)
                        {
                            case "update_mins":
                                this.Minutes = Convert.ToInt32(e.InnerText);
                                break;
                        }
                    }
                }
            }
        }
