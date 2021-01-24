        public class JsonHelper : MonoBehaviour
        {
          public RootObject jsonToRootObject; //access this with your for/foreach loops
          void start(){
          jsonToRootObject = JsonUtility.FromJson<RootObject>(place your json string here);
          }
        }
    
 
    [Serializable]
    public class Data2
    {
        public string nickname;
    }
    [Serializable]
    public class LeaderboardEnrollment
    {
        public int score;
        public Data2 data;
        public long createdAt;
        public long updatedAt;
        public string tCode;
        public int tRank;
        public int tClaimedAt;
        public int tNotifiedAt;
    }
    [Serializable]
    public class TournamentTimetable
    {
        public long tRegistrationStart;
        public string tState;
        public long tPlayEnd;
        public long tRegistrationEnd;
        public long tPlayStart;
    }
    [Serializable]
    public class Name
    {
        public string en;
    }
    [Serializable]
    public class Desc
    {
        public string en;
    }
    [Serializable]
    public class Description
    {
        public Name name;
        public Desc desc;
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
        public string tournamentCode;
        public Description description;
        public CustomJson customJson;
        public List<object> payoutRules;
        public EntryFee entryFee;
    }
    [Serializable]
    public class Data
    {
        public long server_time;
        public LeaderboardEnrollment leaderboardEnrollment;
        public int versionId;
        public TournamentTimetable tournamentTimetable;
        public List<TournamentConfig> tournamentConfigs;
        public bool enrolled;
    }
    [Serializable]
    public class RootObject
    {
        public Data data;
        public int status;
    }
