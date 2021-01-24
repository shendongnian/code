    public class FeedbackViewModel
    {
        public FeedbackViewModel(){
            Feedbacks = new List<FeedbackModel>();
        }
        public List<FeedbackModel> Feedbacks { get; set; }
    }
      Feedbacks = feedbackRepository.Feedbacks.Where(c => c.FeedbackStatus == true).ToList();
