    public class PracticeModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<DrillModel> DrillModels { get; set; }
        public PracticeModel()
        {
            DrillModels = new List<DrillModel>();
        }
    }
In your view you can then loop through your PracticeModel's list of DrillModels and display them as necessary. Assuming you'll have multiple Practice Models, create a partial view that displays each practice model. This makes it easy to work with, and you can re-use that partial view all over your website.
@model PracticeModel
@if (Model != null)
{
    // PracticeModel Details
    @for (int i = 0; i < Model.Drills.Count; i++)
    {
        var drill = Model.Drills[i];
        // DrillModel Details
    }
}
else
{
    //Display Appropriate Html
}
