    static void Main(string[] args)
    {
        var questions = File.ReadAllLines("TriviaQuestions.csv").Select(v => Trivia.FromCsv(v)).ToList();    
        var answers = new List<string>();
    
        foreach (var question in questions)
        {
           Console.WriteLine(question.Questions);
    
            var answer = Console.ReadLine();
            answers.Add(answer);
        }
    
    
        Console.WriteLine("The user answers are...");
        foreach (var answer in answers)
        {
            Console.WriteLine(answer);
        }
    }
