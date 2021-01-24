    public class PagedRequest
    {
        [BindRequired, Range(1, 100, ErrorMessage = "Limit must be from 1 to 100.")]
        public int Top { get; set; }
    
        [BindRequired, Range(0, int.MaxValue, ErrorMessage = "Skip must be 0 or greater.")]
        public int Skip { get; set; }
    }
