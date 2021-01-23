    [Serializable]
    public class ValidationResponse
    {
        public IList<ValidationResult> Violations { get; private set; }
        public IList<ErrorInfo> Errors { get; private set; }
        public bool HasViolations
        {
            get { return Violations.Count > 0; }
        }
        public ValidationResponse(params ValidationResult[] violations)
        {
            Violations = new List<ValidationResult>(violations);
            var errors = from v in Violations
                         from n in v.MemberNames
                         select new ErrorInfo(n, v.ErrorMessage);
            Errors = errors.ToList();
        }
    }
