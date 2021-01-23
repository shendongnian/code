    /// <summary>
    /// The language of the <see cref="Value"/>
    /// </summary>
    [XmlIgnore]
    public CultureInfo Language { get; set; }
    /// <summary>Used for XML serialization.</summary>
    /// <seealso cref="Language"/>
    [XmlAttribute("xml:lang", DataType = "language")]
    public string LanguageString
    {
        get { return (Language == null || string.IsNullOrEmpty(Language.ToString())) ?
                 null : Language.ToString(); }
        set { Language = string.IsNullOrEmpty(value) ?
                 CultureInfo.InvariantCulture : new CultureInfo(value); }
    }
