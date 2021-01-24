    public class TriviaQuestion
    {
    	public string Category { get; set; }
    	
    	public string Type { get; set; }
    	
    	public string Difficulty { get; set; }
    	
    	public string Question { get; set; }
    
        // only need this if not using the ContractResolver
    	[JsonProperty(PropertyName = "correct_answer")]
    	public string CorrectAnswer { get; set; }
    
        // only need this if not using the ContractResolver
    	[JsonProperty(PropertyName = "incorrect_answers")]
    	public List<string> IncorrectAnswers { get; set; }
    }
    
    public class Response
    {
        // only need this if not using the ContractResolver
    	[JsonProperty(PropertyName = "response_code")]	
    	public int ResponseCode { get; set; }
    	
    	public List<TriviaQuestion> Results { get; set; }
    }
