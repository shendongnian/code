    public class Puzzle 
    {
         List<string> answers = new List<string>(4);
         public Puzzle(string question, List<string> answers, int correctAnswer)
         {
               Question = question;
               Answers = answers;
               CorrectAnswer = correctAnswer;
         }
         public string Question {get; private set;}
         public int CorrectAnswer {get; private set;} //or you can make CorrectAnswer a string
         public List<string> Answers { get { return answers;} }
 
    }
