    partial class Scientist
    {
         public Scientist(IPresident president)
         {
              president.HasQuestion += TryToAnswerQuestion;
         }
         private void TryToAnswerQuestion(QuestionArgs question, IPresident asker)
         {
             if(CanAnswerQuestion(question))
             {
                 asker.RecieveAnswer(question,GetAnswer(question));
             }
         }
    }
