    public abstract class ProblemBase<TResult> : IProblem
    {
        public IEnumerable<TResult> Results { get; set; }
    
        IEnumerable IProblem.Results { get { return this.Results; } set { this.Results = value;  } }
    }
