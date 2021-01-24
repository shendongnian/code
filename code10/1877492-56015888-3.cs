    [Serializable]
    // Our results container.
    public class SearchResultsDTO
    {
        public bool IsSuccessful { get; private set; } = false;
        public string ErrorMessage { get; private set; }
        public ICollection<SearchResultDTO> Results { get; private set; } = new List<SearchResultDTO>();
    
        private SearchResultsDTO() {}
    
        public static SearchResultsDTO Success(ICollection<SearchResultDTO> results)
        {
            var results = new SearchResultsDTO
            {
                IsSuccessful = true,
                Results = results
            };
            return results;
        }
        public static SearchResultsDTO Failure(string errorMessage)
        {
            var results = new SearchResultsDTO
            {
                ErrorMessage = errorMessage
            };
            return results;
        }
    }
    
    [Serializable]
    public class SearchResultDTO
    {
        public int ID {get; set;}
        public string Name {get; set;}
        public string Job {get; set;}
        public DateTime Start {get; set;}
        public DateTime End {get; set;}
        public ICollection<string> Logs {get; set;} = new List<string>();  
    }
