    public class ResultWrapper
    {
        public Task<ProcessedURLResult> InnerTask { get; set; }
        public ProcessedURLResult Result
        {
            get
            {
                return InnerTask.Result;
            }
        }
    }
