    public class LoanStatusVectorOverTime<TStatus>
    {
        public Func<TStatus, int> GetKeyValue { get; set; }
    }
    // When the object gets instantiated
    loanStatusVectorOverTime.GetKeyValue = status => (int)status;
