    [Required(ErrorMessage = "Du skal angive hvilken type aktiven er.")]
    [DisplayName("Aktiv-type")]
    [Column(TypeName = "int", Name="ActiveType_ID")]
    public ActiveType ActiveType
    {
        get;
        set;
    }
    [Column(TypeName = "int", Name="Place_ID")]
    [DisplayName("Sted")]
    public Place Place
    {
        get;
        set;
    }
