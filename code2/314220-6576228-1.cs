    public class ReviewerService
    {
        private readonly Reviewer _reviewer;
    
        public void StoreReview(ReviewModel model)
        {
            // validate input here
    
            // do business logic here
            if (model.IsPendingState && _reviewer.CanPutIntoPendingState)
            {
                this.PutIntoPendingState("pending state");
            }
            else
            {
                this.AddReview(model.Review);
            }
    
        }
    
        private void AddReview(string review)
        {
            // do add review logic here
        }
    
        private void PutIntoPendingState(string pendingState)
        {
            
           // do PutIntoPendingState logic here
            
        }
    }
    
    public class ReviewModel
    {
        public string Review { get; set; }
        public bool IsPendingState { get; set; }
    }
    
    public class Editor
    {
        private readonly ReviewerService _reviewerService;
    
        public Editor(ReviewerService reviewerService)
        {
            _reviewerService = reviewerService;
        }
    
        public void SaveCommand()
        {
            ReviewModel model = new ReviewModel() {Review="user review",IsPendingState=user chose a pending state };
            
            _reviewerService.StoreReview(model);
        }
    }
