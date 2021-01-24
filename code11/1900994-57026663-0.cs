    @using WebApplication2.Models;
    @model List<Question>
    @{
        ViewBag.Title = "Home Page";
        var answers = (List<Answer>)ViewBag.Answers;
    }
    @using (Html.BeginForm())
    {
        <br />
        foreach (var question in Model)
        {
            @Html.Label(question.name)
            {
                foreach (var answer in answers)
                {
                    if (question.ID == answer.QuestionID)
                    {                
                        <input type="radio" name="@question.controlName" value="@answer.Answer1"/>@answer.Answer1 
                        <input type="radio" name="@question.controlName" value="@answer.Answer1"/>@answer.Answer2
                    }
                }
            }
            <br />
        }
        <input type="submit" value="ok" />
    } 
