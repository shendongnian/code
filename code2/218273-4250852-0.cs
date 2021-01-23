    [XmlIgnore]
    public Language Language { get; set; }
    
    [XmlAttribute("Language")]
    public string LanguageAsString
    {
        get { return Language.ToString(); }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                Language = default(Language);
            }
            else
            {
                Language = (Language)Enum.Parse(typeof(Language), value);
            }
        }
    }
