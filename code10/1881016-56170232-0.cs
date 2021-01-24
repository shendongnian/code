public class JsonObjects
{
    public dynamic data;
    public AccountRoot jsonBody;
    public void AQuestions(string productId,Table table)
    {
        data = table.CreateDynamicInstance();
        jsonBody = new AccountRoot()
        {
            productId = productId,
            questions = new[]
            {
                new Questions() 
                {
                    questionId = "b2b-2.01",
                    question ="Q1",
                    answers = new []
                    {
                        new Answers()
                        {
                            answerValue = data.answerValue1
                        }
                    }
                }
            }
        };
    }
}
