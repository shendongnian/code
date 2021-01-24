    void Main()
    {
        bool check = true;
        var name = ReadInput("Enter your name:",ValidationExpressionsForName);
        // var surname = ReadInput("Enter your SurName :",ValidationExpressionsForSurName);
        // so on
        Console.WriteLine("Your name is: " + name);
    }
    
    public string ReadInput(string inputMessage,Func<string,IEnumerable<EvaluationExpression>> evaluationExpression)
    {
    	while (true) 
        { 
    		Console.Write(inputMessage);
    		string term = Console.ReadLine();
    
            if(evaluationExpression(term).Any(x=>x.Expression()))
            {
                Console.WriteLine(evaluationExpression(term).First(x=>x.Expression()).Message);
            }
            else
                return term;
    
        }
    
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
