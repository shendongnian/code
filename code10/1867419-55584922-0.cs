        public class JsonHelper : MonoBehaviour
        {
          public RootObject jsonToRootObject; //access this w foreach or for loops
          void start(){
          jsonToRootObject = JsonUtility.FromJson<RootObject>(place your json string here);
          }
        }
    
 
    [Serializable]
    public class Data2
    {
        public string nickname { get; set; }
    }
    [Serializable]
    public class LeaderboardEnrollment
    {
        public int score { get; set; }
        public Data2 data { get; set; }
        public long createdAt { get; set; }
        public long updatedAt { get; set; }
        public string tCode { get; set; }
        public int tRank { get; set; }
        public int tClaimedAt { get; set; }
        public int tNotifiedAt { get; set; }
    }
    [Serializable]
    public class TournamentTimetable
    {
        public long tRegistrationStart { get; set; }
        public string tState { get; set; }
        public long tPlayEnd { get; set; }
        public long tRegistrationEnd { get; set; }
        public long tPlayStart { get; set; }
    }
    [Serializable]
    public class Name
    {
        public string en { get; set; }
    }
    [Serializable]
    public class Desc
    {
        public string en { get; set; }
    }
    [Serializable]
    public class Description
    {
        public Name name { get; set; }
        public Desc desc { get; set; }
    }
    [Serializable]
    public class CustomJson
    {
    }
    [Serializable]
    public class EntryFee
    {
    }
    [Serializable]
    public class TournamentConfig
    {
        public string tournamentCode { get; set; }
        public Description description { get; set; }
        public CustomJson customJson { get; set; }
        public List<object> payoutRules { get; set; }
        public EntryFee entryFee { get; set; }
    }
    [Serializable]
    public class Data
    {
        public long server_time { get; set; }
        public LeaderboardEnrollment leaderboardEnrollment { get; set; }
        public int versionId { get; set; }
        public TournamentTimetable tournamentTimetable { get; set; }
        public List<TournamentConfig> tournamentConfigs { get; set; }
        public bool enrolled { get; set; }
    }
    [Serializable]
    public class RootObject
    {
        public Data data { get; set; }
        public int status { get; set; }
    }
