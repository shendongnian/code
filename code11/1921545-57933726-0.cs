        public class GithubReleaseModel
        {
  
            internal GithubReleaseModel()
            {
                // internal constructor 
            }
 
            public bool IsExistNewVersion { get; set; }
            public string Url { get; set; }
            public string Changelog { get; set; }
            public string Version { get; set; }
            public string DownloadUrl { get; set; }
            public string Size { get; set; }
            public bool IsPreRelease { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime PublishedAt { get; set; }
        }
        public static GithubReleaseModel IsNewVersionExistGithub(string Username, string Repository)
        {
            var model = new GithubReleaseModel();
            ...
            return model;
        }
