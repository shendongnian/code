    public class YouTubeLink
    {
       int Quality{get;private set;}
       string Type{get;private set;};
       string Url{get;private set;};
       public YouTubeLink(...){...}
    }
    
    public class YouTubeVideoInfo
    {
       public ReadOnlyCollection<YouTubeLink> Links{get;}
       ...
    }
