    [XmlIgnore]
    public ApplicationLanguage Lang { get; set; }
    [XmlElement("Language")]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public string LangSerialized {
        get { return Lang == null ? null : Lang.Name; } // or where-ever "he" comes from
        set { Lang = value == null ? null : ApplicationLanguagesList.GetByName(value); }
    }
