     public class ReleaseResponse
            {
                [JsonProperty("value")]
                public List<ReleaseItem> Value { get; set; }
            }
         
            public class ReleaseItem
            {
    
                [JsonProperty("name")]
                public string Name { get; set; }
    
                [JsonProperty("Id")]
                public int Id { get; set; }
    
            }
    
            static void Main(string[] args)
            {
                string tfsURL = "TFS URL";
                string releaseDefurl = $"{tfsURL}/_apis/release/definitions?$expand=artifacts&api-version=3.2-preview.3";
                const int agentPoolID = "AGENT Pool ID";
                List<string> relevantReleases = new List<string>(); 
                WebClient client = new WebClient();
                client.UseDefaultCredentials = true;
                client.Headers.Add("Content-Type", "application/json");
               var releaseList = client.DownloadString(releaseDefurl);
               var allReleases = JsonConvert.DeserializeObject<ReleaseResponse>(releaseList).Value;
                foreach (var release in allReleases)
                {
                    string releaseInfoApi = $"{tfsURL}/_apis/Release/definitions/{release.Id}";
                    var getReleseInfo = client.DownloadString(releaseInfoApi);
                    var releaseInfo = JsonConvert.DeserializeObject<TFSLogic.RootObject>(getReleseInfo);
                    var deploymentAgents = releaseInfo.environments.ToList().Where(e => e.deployPhases.FirstOrDefault().deploymentInput.queueId == agentPoolID).Count();
                    if (deploymentAgents > 0)
                    {
                        relevantReleases.Add(release.Name);
                    }
    
                }
            }
        }
