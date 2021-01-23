    public class ReportParameters
    {
        public int PrimaryAccount { get; private set; }
        // Other properties
        private ReportParameters(int primaryAccount, ....)
        {
            this.PrimaryAccount = primaryAccount;
        }
        // Could use a constructor instead, but I prefer methods when they're going to
        // do work
        public static ReportParameters Parse(string report)
        {
            // Parse the parameter, save values into local variables, then
            return new ReportParameters(primaryAccount, ...);
        }
    }
