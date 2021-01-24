public class AnswerModel
{
   // Omitted for simplicity
}
    
public class QuestionModel
{
    public List<AnswerModel> Answers { get; set; } = new List<AnswerModel>();
}
You shouldn't do *.ToList()* before *.Where()* because you're actually materialize the entire entity (aka table). 
It's better if you use a join to do your query or if you prefer you could use the NavigationProperty, if you have one, to track the collection of **Answers** related to your **Question**. 
[LINQ basics](https://docs.microsoft.com/it-it/ef/core/querying/basic)
However I use your approach with two separated query:
    var model = new List<QuestionModel>();
    var questions = _context.SurveyQuestions.Where(x => x.MainSurveyId == Surveyid).ToList();
    var answers = _context.SurveyCompetitorAnswer.Where(x => x.MainSurveyId == Surveyid).ToList();
    foreach (var q in questions){
    	var qModel = new QuestionModel();
    	qModel.Answers.AddRange(answers.Where(x => x.SurveyQuestionId == q.Id).ToList());
    	model.Add(qModel);
    }
And with a more simple and aggregated model:
<tbody>
    @foreach (var q in Model)
    {
        <tr>
            <td scope="row">
                @q.Question
            </td>
            @foreach (var a in q.Answers)
            {
                <td scope="row">
                    @a.Answer
                </td>    
            }
        </tr>
    }
</tbody>
If you would share your entities, we could optimize the query!
**Happy coding!**
