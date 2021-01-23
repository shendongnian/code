    public abstract class Result : BaseSoapAnswer
    {
        public Result()
        {
            this.Success = true;
        }
        public bool Success { get; set; }
    }
    public class OpenAccountResult : Result 
    // ...
    public class AnotherResult : Result 
