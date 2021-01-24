        public class ResponseBaseClass
        {
            public IEnumerable<TeamStatsClass> teams { get; set; }
            public string copyright { get; set; }
        }
        public class TeamStatsClass
        {
            public int id { get; set; }
            public string name { get; set; }
            public Division division { get; set; }
        }
        public class Division
        {
            public int id { get; set; }
            public string name { get; set; }
            public string nameShort { get; set; }
            public string link { get; set; }
        
        }
     HttpClient Http = new HttpClient();
     var json = await Http.GetStringAsync("https://statsapi.web.nhl.com/api/v1/teams?sportId=1");
     var model = JsonConvert.DeserializeObject<ResponseBaseClass>(json);
     var yourTeamModelObj = model.teams;
    
