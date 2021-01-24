    public sealed class ErrorsResponseModel : Dictionary<string, List<string>>
    {
        //If you still want to access data with property.
        public List<string> Username => this["Username"];
        ...
    }
