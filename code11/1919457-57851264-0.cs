            private double? _GRDIP { get; set; }
            [XmlElement("GRDIP")]
            public string GRDIP {
                get { return _GRDIP.ToString(); }
                set { _GRDIP = (value == string.Empty) ? null : (double?)double.Parse(value);}
            }
