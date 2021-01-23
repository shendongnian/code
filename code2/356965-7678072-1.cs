    public partial class User
    {
        public ICollection<Survey> CompletedSurveys
        {
            get { return Surveys.Where(s => s.IsCompleted); }
        }
    }
