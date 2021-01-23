    public partial class GetMyDataResults
    {
        public bool IsAuthorised
        {
            get { return DateAuthorised.HasValue; }
        }
    }
