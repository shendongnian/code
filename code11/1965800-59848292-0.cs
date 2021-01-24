public abstract class Athlete
{
    [JsonProperty(Required = Required.Always)]
    public string AthleteType { get; set; }
    // and whatever else is relevant for all athletes
}
public class SoccerPlayer : Athlete
{
    // Why is that a string? I would use an enum: Left/Right/Both (for players with no favorite foot)
    [JsonProperty(Required = Required.Always)]
    public string RightOrLeftFood{ get; set; }
}
public class GolfPlayer : Athelte
{
    // Here you have whatever is relevant for golf players
}
Then you can check what is the value of AthleteType in the Json and deserialize the specific type based on the string. 
