c#
protected override void Seed(cq.Models.ApplicationDbContext context) {
    SurveyTemplate surveyTemplate = context.SurveyTemplates.Find("d87ab2a8-4eb4-4272-b7e4-afe2f8999b4e");
    if (!context.QuestionTemplates.Any(q => q.Text == questionTemplate.Text && q.SurveyTemplate.Id == questionTemplate.SurveyTemplate.Id)) {
        context.QuestionTemplates.Add(new QuestionTemplate {
            Id = Guid.NewGuid().ToString(),
            Text = "What is your contact info?",
            Type = "Contact Info",
            SurveyTemplate = surveyTemplate
        });
        
        context.SaveChanges();
    }
}
c#
public class QuestionTemplate {
    public string Id { get; set; }
    public string Text { get; set; }
    public string Type { get; set; }
    public string SurveyTemplateId { get; set; }
    [ForeignKey("SurveyTemplateId")]
    public SurveyTemplate SurveyTemplate { get; set; }
}
I hope I helped someone!
Edit: Since apparently AddOrUpdate is quite unreliable, i switched it up, you should see it in the code. Cheers!
