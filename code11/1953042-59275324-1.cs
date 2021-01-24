c#
public class Game
{
    ...
    public int HomeTeamId { get; set; }
    public Team HomeTeam { get; set; }
    public int AwayTeamId { get; set; }
    public Team AwayTeam { get; set; }
}
public class Team
{
    ...
    public List<Game> HomeGames { get; set; }
    public List<Game> AwayGames { get; set; }
}
For a team it's meaningful to make a distinction between home and away games, for example to compare results in both types of games.
And the mapping:
c#
modelBuilder.Entity<Game>()
    .HasOne(g => g.HomeTeam)
    .WithMany(t => t.HomeGames)
    .HasForeignKey(t => t.HomeTeamId)
    .HasPrincipalKey(t => t.Id);
modelBuilder.Entity<Game>()
    .HasOne(g => g.AwayTeam)
    .WithMany(t => t.AwayGames)
    .HasForeignKey(t => t.AwayTeamId).OnDelete(DeleteBehavior.NoAction)
    .HasPrincipalKey(t => t.Id);
If using Sql Server, this delete behavior instruction is necessary to prevent disallowed multiple cascade paths.
