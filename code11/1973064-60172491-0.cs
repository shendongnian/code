     private static char AnswerTheQuestion(string question, int answers) {
       Console.WriteLine(question);
       // Loop until...
       while (true) {
         string answer = Console.ReadLine().Trim();
         if (answer.Length == 1) {
           char result = char.ToLower(answer[0]);
           if (result >= 'a' && result <= 'a' + answers)
             return result; // ...user provide an answer in expected format
         }
         Console.WriteLine($"Sorry, provide an answer in [a..{(char)('a' + answers)}] range");
       }
     }
