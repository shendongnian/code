     private static char AnswerTheQuestion(string question, int answers) {
       Console.WriteLine(question);
       // Loop until...
       while (true) {
         // Let's be nice and tolerate leading / trailing spaces
         string answer = Console.ReadLine().Trim();
         if (answer.Length == 1) {
           char result = char.ToLower(answer[0]); // let's ignore case ('A' == 'a' etc.)
           if (result >= 'a' && result <= 'a' + answers)
             return result; // ...user provide an answer in expected format
         }
         // Comment it out if you want just to ignore invalid input 
         Console.WriteLine($"Sorry, provide an answer in [a..{(char)('a' + answers)}] range");
       }
     }
