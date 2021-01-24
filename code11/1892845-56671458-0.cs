    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace DT.Models
    {
        [Description("GET or DELETE using Id")]
        public class ModelA
        {
            public int Id { get; set; }
            public string HotfixID { get; set; }
            public string Description { get; set; }
            public string ExtendedDescription { get; set; }
            public string BugTrackCases { get; set; }
            public string Type { get; set; }
            public string AppVersion { get; set; }
            public DateTime HotfixDate { get; set; }
            public string HotfixLocation { get; set; }
            public int ClientID { get; set; }
            public List<DeploySite> DeploySites { get; set; }
            public List<FBCase> BugTrackCaseList { get; set; }
            public int? OriginalId { get; set; }
            public string CaseType { get; set; }
            public bool HasSQL { get; set; }
            public bool HasConfig { get; set; }
            public bool HasLibraries { get; set; }
            public bool HasWebApps { get; set; }
            [NotMapped]
            public string ClientName { get; set; }
            [NotMapped]
            public string Status { get; set; }
            [NotMapped]
            public bool Complete { get; set; }
            [NotMapped]
            public DateTime LastUpdatedDate { get; set; }
        }
    }
