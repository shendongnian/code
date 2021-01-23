    [System.Xml.Serialization.XmlElementAttribute(ElementName = "Confirm", IsNullable=true)]
        public ConfirmType Confirm
        {
            get
            {
                return this.confirmField;
            }
            set
            {
                this.confirmField = value;
                this.RaisePropertyChanged("Confirm");
            }
        }
