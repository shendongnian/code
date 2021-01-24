C#
    interface IAnswer { };
	
	public class ExampleAnswer : IAnswer
	{
		public ExampleAnswer(String JSONObject)
		{
			// Parse JSON here
		}
	}
	
	delegate IAnswer AnswerConstructor(String JSONObject);
	
	Dictionary<int, AnswerConstructor> Constructors = new Dictionary<int, AnswerConstructor>()
	{
		{1234, ((AnswerConstructor)(json => new ExampleAnswer(json)))}
		// Add all answer types here
	};
	
	Dictionary<int, IAnswer> ParseAnswers(Dictionary<int, String> JSONObjects)
	{
		var result = new Dictionary<int, IAnswer>();
		foreach (var pair in JSONObjects)
			result.Add(pair.Key, Constructors[pair.Key](pair.Value));
			
		return result;
	}
