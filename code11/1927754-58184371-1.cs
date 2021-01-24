csharp
public class Question {
   // The question that is asked.
   public string question;
   // All known answers
   public List<Answer> answers = new List<Answer>();
}
public class Answer {
   // The answer text
   public string answer;
   // The score awarded for this answer.
   public int score;
}
Now you can read your data from where-ever you want to read it and put it into these objects. Here is how you would create these objects manually:
csharp
var question = new Question { question  = "What is the color of the sky", answers = { 
    new Answer { answer = "It is blue", score = 1},
    new Answer { answer = "It is yellow", score = 0} 
    } 
};
This way you have the question and all its answers in a nice structure together for processing. 
