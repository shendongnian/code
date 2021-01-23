public class Team
{
    [Key]
    public int TeamId { get; set;} 
    public string Name { get; set; }
    [InverseProperty(nameof(Match.HomeTeam))]
    public ICollection<Match> HomeMatches{ get; set; }
    [InverseProperty(nameof(Match.GuestTeam))]
    public ICollection<Match> AwayMatches{ get; set; }
}
public class Match
{
    [Key]
    public int MatchId { get; set; }
    [ForeignKey(nameof(HomeTeam)), Column(Order = 0)]
    public int HomeTeamId { get; set; }
    [ForeignKey(nameof(GuestTeam)), Column(Order = 1)]
    public int GuestTeamId { get; set; }
    public float HomePoints { get; set; }
    public float GuestPoints { get; set; }
    public DateTime Date { get; set; }
    public Team HomeTeam { get; set; }
    public Team GuestTeam { get; set; }
}
  [1]: https://docs.microsoft.com/en-us/ef/core/modeling/relationships#inverseproperty
