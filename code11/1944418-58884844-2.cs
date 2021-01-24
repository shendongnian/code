	public class Question
	{
		public int Id {get;set;}
		public string QuestionText {get;set;}
		public string AnswerType {get;set;}
		public string[] ProvidedAnswers {get;set;}
		public string[] UserAnswers {get;set;}
		public string[] CorrectAnswers      {get;set;}
		public int  CorrectMoveToQuestion    {get;set;}
		public int  IncorrectMoveToQuestion  {get;set;}
	}
	public class QuestionService {
		public bool ValidateAnswers(string[] correctAnswers, string[] userAnswers)
		{
			//PseudoCode - I'm not doing your work for you.
			foreach(var uA in userAnswers)
			{
				//Check that correct Answers match and that the user has not selected any wrong answers
			}
			return true; // false; depending on result		
		}
	}
