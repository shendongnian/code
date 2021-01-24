    // HINWEIS: Für den generierten Code ist möglicherweise mindestens .NET Framework 4.5 oder .NET Core/Standard 2.0 erforderlich.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute( "code" )]
    [System.Xml.Serialization.XmlTypeAttribute( AnonymousType = true )]
    [System.Xml.Serialization.XmlRootAttribute( Namespace = "", IsNullable = false, ElementName = "section" )]
    public partial class Section
    {
        private List<SectionRow> _rowField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute( "row" )]
        public List<SectionRow> Rows
        {
            get
            {
                return this._rowField;
            }
            set
            {
                this._rowField = value;
            }
        }
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute( "code" )]
    [System.Xml.Serialization.XmlTypeAttribute( AnonymousType = true )]
    public partial class SectionRow
    {
        private List<SectionRowCol> _columnsField;
        private int _codeField;
        private string _valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute( "col" )]
        public List<SectionRowCol> Columns
        {
            get
            {
                return this._columnsField;
            }
            set
            {
                this._columnsField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute( AttributeName = "code" )]
        public int Code
        {
            get
            {
                return this._codeField;
            }
            set
            {
                this._codeField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute( AttributeName = "s1" )]
        public string Value
        {
            get
            {
                return this._valueField;
            }
            set
            {
                this._valueField = value;
            }
        }
    }
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute( "code" )]
    [System.Xml.Serialization.XmlTypeAttribute( AnonymousType = true )]
    public partial class SectionRowCol
    {
        private byte _codeField;
        private string _valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute( AttributeName = "code" )]
        public byte Code
        {
            get
            {
                return this._codeField;
            }
            set
            {
                this._codeField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this._valueField;
            }
            set
            {
                this._valueField = value;
            }
        }
    }
