                private string _Description { get; set; }
                [XmlElement(ElementName = "DESCRIPTION")]
                public Description Description
                {
                    get { return new Description() { P = _Description.Split(new char[] { ',' }).Select(x => new P() { Text = x}).ToArray() }; }
                    set
                    {
                        _Description = string.Join(",",value.P.Select(x => x.Text));
                    }
                }
                private string _MoreInfo { get; set; }
                [XmlElement(ElementName = "MOREINFO")]
                public MoreInfo MoreInfo
                {
                    get { return new MoreInfo() { P = _MoreInfo.Split(new char[] { ',' }).Select(x => new P() { Text = x }).ToArray() }; }
                    set
                    {
                        _MoreInfo = string.Join(",", value.P.Select(x => x.Text));
                    }
                }
