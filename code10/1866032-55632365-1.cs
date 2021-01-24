    public class ErrorModel
    {
        public string Error { get; set; }
        public int Id { get; set; }
        public List<int> Values { get; set; }
    }
    //filter
    var error = new ErrorModel
    {
        Error = context.Exception.Message,
        Id = 1,
        Values = new List<int> { 1, 2, 3 }
    };
    context.Result = new ObjectResult(error)
    {
        StatusCode = 500
    };
