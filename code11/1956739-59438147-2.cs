    void Main()
    {
    	bool check = true;
        Console.Write("Enter your name:");
        string name = Console.ReadLine();
    
    	while (check) 
    	{ 
    		if(ValidationExpressionsForName(name).Any(x=>x.Expression()))
    		{
    			Console.WriteLine(ValidationExpressionsForName(name).First(x=>x.Expression()).Message);
    			name = Console.ReadLine();	
    		}
    		else
    			check = false;
    		
        }
    
    	Console.WriteLine("Your name is: " + name);
    }
    
    public IEnumerable<EvaluationExpression> ValidationExpressionsForName(string message) => new EvaluationExpression[]
    {
    	new EvaluationExpression{ Expression = ()=>String.IsNullOrWhiteSpace(message), Message= "Name cannot be empty"},
    	new EvaluationExpression{ Expression = ()=>message.All(char.IsDigit),Message ="Your name cannot be made up of numbers"},
    	new EvaluationExpression{ Expression = ()=>message.Any(char.IsDigit),Message="Your name cannot contain numbers"}
    };
    
    public class EvaluationExpression
    {
    	public Func<bool> Expression{get;set;}
    	public string Message{get;set;}
    }
