public class Threat
        {
            public object digest { get; set; }
            public object hash { get; set; }
            public string url { get; set; }
            public object ETag { get; set; }
        }
        public class Match
        {
            public string cacheDuration { get; set; }
            public string platformType { get; set; }
            public Threat threat { get; set; }
            public object threatEntryMetadata { get; set; }
            public string threatEntryType { get; set; }
            public string threatType { get; set; }
            public object ETag { get; set; }
        }
        public class RootObjSB
        {
            public List<Match> matches { get; set; }
            public object ETag { get; set; }
        }
and i deserialize it like this:
string SB_Result = await CheckUrl("MyAPIKey", "Bad_URL");
var obj = new JavaScriptSerializer().Deserialize<RootObjSB>(SB_Result);
string threat = obj.matches[0].threatType;
Console.WriteLine(threat);
I really don't know why the first option I tried didn't parse the data correctly but this was how I overcame that problem. Hope it helps anyone going through the same thing
