    // This you might not need anymore
    [System.Serializable] 
    public class SearchInfo 
    { 
        public MovieSearchInfo[] Search; 
    } 
    
    [System.Serializable] 
    public class MovieSearchInfo 
    { 
        public string Title; 
        public string Year; 
        public string imdbID;
        public string Type; 
    }
