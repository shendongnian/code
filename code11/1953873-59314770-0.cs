    [ForeignKey("FirstTeam")]
    public int FirstTeamId { get; set; }
    public Team FirstTeam { get; set; }
    [ForeignKey("SecondTeam")]
    public int SecondTeamId { get; set; }
    public Team SecondTeam { get; set; }
