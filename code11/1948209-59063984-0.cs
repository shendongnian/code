	public class QuestionInfo 
    {
        string Question {get; }
	    string Answer {get; }
	    int Points {get; }
	
	    public QuestionInfo(string question, string answer, int points)
	    {
		    Question = question;
		    Answer = answer;
		    Points = points;
	    }
	
	    public void WriteCsv(TextWriter tw)
	    {
		    tw.WriteLine($"{Question},{Answer},{Points}")
	    }
	
	    public static void WriteCsv(List<QuestionInfo> questions, TextWriter tw)
	    {
		    foreach (var question in questions)
		    {
			    question.WriteCsv(tw);
		    }
	    }
    }
