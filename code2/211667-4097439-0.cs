    public class Result
    {
        protected int Code { get; set; }
        protected List<string> Messages { get; set; }
        protected Result(int code, List<string> messages)
        {
            Code = code;
            Messages = messages;
        }
        public static Result Success(int code, List<string> messages)
        {
            Result result = new Result(code, messages);
            return result;
        }
    }
    public class ResultWithName : Result
    {
        protected string Name { get; set; }
        protected ResultWithName(int code, List<string> messages, string name) :
            base(code, messages)
        {
            Name = name;
        }
        public static ResultWithName Success(int code, List<string> messages, string name)
        {
            ResultWithName result = new ResultWithName(code, messages, name);
            return result;
        }
    }
