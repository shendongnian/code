        public abstract class Reviewer
    {
        public abstract bool CanPutIntoPendingState { get; }
        
    }
    
    public class InitialReviewer : Reviewer
    {
        public override bool CanPutIntoPendingState 
        {
            get
            {
                return true;
            }
        }
    }
    
    public class SecondReviewer : Reviewer
    {
    	public override bool CanPutIntoPendingState 
    	{
    		get
    		{
    			return false;
    		}
    	}
    }
    
    public class ReviewerService
    {
        private readonly Reviewer _reviewer;
    
        public void AddReview(string review)
        {
            // do add review logic here
        }
       
    
    	public void PutIntoPendingState(string pendingState) 
    	{ 
    		if (_reviewer.CanPutIntoPendingState ) 
    		{
                // do PutIntoPendingState logic here
    		}
    	}
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
            if(user chose a pending state) // Pending state is a dropdown.
                _reviewerService.PutIntoPendingState("pending state");
            else // the user made a complete review
                _reviewerService.AddReview("user review");
        }
    }
