    private static Random rng = new Random();  
	public static void Shuffle<T>(this IList<T> list)  
	{  
		int n = list.Count;  
		while (n > 1)
		{  
			n--;  
			int k = rng.Next(n + 1);  
			T value = list[k];  
			list[k] = list[n];  
			list[n] = value;  
		}  
	}
	public static void Main(string[] args)
	{
		var quizz = new Dictionary<string, string>
		{
			{ "What is the answer to the Ultimate Question of Life, the Universe, and Everything ?", "42" },
			{ "What is your name ?", "Sir Arthur, king of the Britons" },
			{ "What is your quest ?", "To seek the Holy Grail" },
			{ "What is the air-speed velocity of an unladen swallow?", "What do you mean ? An African or European swallow ?" }
		};
		var questions = quizz.Keys.ToList();
		questions.Shuffle();
		
		foreach (var question in questions)
		{
			Console.WriteLine(question);
			if (Console.ReadLine() != quizz[question])
			{
				Console.WriteLine("You failed");
				Console.ReadLine();
				break;
			}
			else
			{
				Console.WriteLine("Nice !");
			}
		}
	}
