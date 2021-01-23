    internal class OperationResult
    {
        public OperationResult(bool result, List<string> errors)
        {
            Result = result;
            Errors = errors;
        }
        readonly bool Result { get; set; }
        readonly List<string> Errors { get; set; }
    }
