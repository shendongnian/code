[FirestoreData]
public class Participant
{
    [FirestoreProperty]
    public string playerName { get; set; }
    [FirestoreProperty("playerExperience")] //you can give the properties custom names as well
    public int experience { get; set; }
 
    //so on
    public int level { get; set; }
    public string characterName { get; set; }
    public string playerUid { get; set; }
    public object joined { get; set; }
    public string type { get; set; }
    public object abilities { get; set; }
    public int roll { get; set; }
    public bool? isCurrent { get; set; }
    public int sizeModifier { get; set; }
    public int initiative { get; set; }
    public bool? hasPlayedThisTurn { get; set; }
    public string portraitUrl { get; set; }
}
or
(Disclaimer there may be a cleaner way of doing this)
by converting the participant to an ExpandoObject
ExpandoObject [https://docs.microsoft.com/en-us/dotnet/api/system.dynamic.expandoobject][1]
using Newtonsoft.Json
or a solution not requiring Newtonsoft.Json seems to exist as well:
https://stackoverflow.com/questions/46948289/how-do-you-convert-any-c-sharp-object-to-an-expandoobject 
var serializedParticipant = JsonConvert.SerializeObject(participant);
var deserializedParticipant = JsonConvert.DeserializeObject<ExpandoObject>(serializedParticipant);
and then updating firestore with your Participants as an `ExpandoObject` instead of `Model.Participant`
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.dynamic.expandoobject
