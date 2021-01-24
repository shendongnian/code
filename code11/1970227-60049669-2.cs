    /// <summary>
    /// Represents the result of an ADO.Net operation.
    /// </summary>
    public class AdoNetResult {
        private List<Exception> _errors = new List<Exception>();
        public bool Succeeded { get; protected set; }
        public IEnumerable<Exception> Errors => _errors;
        public static AdoNetResult Success { get; } = new AdoNetResult { Succeeded = true };
        public static AdoNetResult Failed(params Exception[] errors) {
            var result = new AdoNetResult { Succeeded = false };
            if (errors != null) {
                result._errors.AddRange(errors);
            }
            return result;
        }
    }
    
