    public class Review {
        public RecommendationType Types { get; set; }
        public bool IsReviewFor(RecommendationType types) {
            // bitwise comparison, check if the flags 
            // given are in the Types property also
        }
    }
