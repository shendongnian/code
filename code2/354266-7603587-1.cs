    public class Challenge
    {
    	public int Id {get;set;}
    	public int Difficulty {get;set;}
    	public bool IsCompleted {get;set;}
    	public string Title {get;set;}
    	public string Question {get;set;}
    	public string Answer {get;set;}
    }
    
    public class MainPage
    {
    	private List<Challenge> _challenges;
    	private Random rand = new Random();
    	public MainPage()
    	{
    		_challenges = new List<Challenge> {
    			new Challenge {
    					Id = 1,
    					Difficulty = 20,
    					Title = "What came first?",
    					Question =  "The chicken or the egg?",
    					Answer = "The egg." },
    			new Challenge {
    					Id = 2,
    					Difficulty = 30,
    					Title = "Make 7 from 12?",
    					Question =  "Can you prove 7 is half of 12?",
    					Answer = "VII" }};
    	}
    	
    	public void LoadChallenge(Challenge challenge)
    	{
    		Difficulty.Test = String.Format("%{0}", callenge.Difficulty);
    		Completeted.Value = challenge.IsCompleted;
    		Title.Test = challenge.Title;
    		// etc
    	}
    	
    	public void StartNewChallenge()
    	{
    		Challenge nextChallenge = null;
    		while(nextChallenge == null)
    		{
    			var nextId = rand.Next(1,2);
    			nextChallenge = _challenges
    				.Where(x => x.Id == nextId && !x.IsCompleted)
    				.SingleOrDefault(); // default to null if completed == true
    		}
    		LoadChallenge(nextChallenge);
    	}
    	
    }
    	
