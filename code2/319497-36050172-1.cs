        [System.Xml.Serialization.XmlAttributeAttribute()]
        public barEnum foo {
            get {
                return this.fooField;
            }
            set {
                this.fooField = value;
                this.fooFieldSpecified = true;
            }
        }
