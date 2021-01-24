       static void Main(string[] args) { 
         char result = AnswerTheQuestion(string.Join(Environment.NewLine,
               "What is the capital of Russia?",
               "  a. Saint-Petersburg",
               "  b. Moscow",
               "  c. Novgorod"),
           3);
    
         Console.WriteLine($"{(result == 'b' ? "correct" : "incorrect")}");
         Console.ReadKey(); 
       }
