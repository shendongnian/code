    public class TriviaQuestion
    {
    	public string Category { get; set; }
    	
    	public string Type { get; set; }
    	
    	public string Difficulty { get; set; }
    	
    	public string Question { get; set; }
    
    	[JsonProperty(PropertyName = "correct_answer")]
    	public string CorrectAnswer { get; set; }
    
    	[JsonProperty(PropertyName = "incorrect_answers")]
    	public List<string> IncorrectAnswers { get; set; }
    }
    
    public class Response
    {
    	[JsonProperty(PropertyName = "response_code")]	
    	public int ResponseCode { get; set; }
    	
    	public List<TriviaQuestion> Results { get; set; }
    }
