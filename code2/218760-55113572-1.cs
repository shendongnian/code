    System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="your namespace")]
    public partial class advancedSearchRequest : object, System.ComponentModel.INotifyPropertyChanged {
        
        private vehicleType vehicleTypeField;
        
        private bool vehicleTypeFieldSpecified;
        
        private string searchField;
        
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public vehicleType vehicleType {
            get {
                return this.vehicleTypeField;
            }
            set {
                this.vehicleTypeField = value;
                this.RaisePropertyChanged("vehicleType");
            }
        }
		
		/// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool vehicleTypeSpecified {
            get {
                return this.vehicleTypeFieldSpecified;
            }
            set {
                this.vehicleTypeFieldSpecified = value;
                this.RaisePropertyChanged("vehicleTypeSpecified");
            }
        }
        
		[System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string search {
            get {
                return this.searchField;
            }
            set {
                this.searchField = value;
                this.RaisePropertyChanged("search");
            }
        }
		
	}
