    public class DetailsViewModel
    {
        // One-way members:
    
        [BindNever]
        public String PageTitle { get; internal set; }
        public Question TheQuestion  { get; internal set; }
        public List<Answer> TheAnswers { get; internal set; }
        // Two-way members:
        // (you don't have any forms, so this area is empty)
    }
