    public class PropertySearchFile
        {
            public int PropertyFileId { get; set; }
            public string FileUrl { get; set; }
            public string FileName { get; set; }
    
            public int PropertyId { get; set; } //THat is assuming that PropertyId is the PK for the PublicPropertySearchResult class 
        }
