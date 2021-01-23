    public abstract class JobBase<TDetails>
    {
        private TDetails details;
        protected TDetails Details
        {
            get
            {
                if (details == null)
                {
                    this.details = this.LoadDetails();
                }
                return this.details;
            }
        }
        protected virtual TDetails LoadDetails()
        {
            // Some kind of deserialization of TDetails from your DB storage.
        }
    }
    public class ExampleJob : JobBase<ExampleJob.ExampleJobDetails>
    {
        public class ExampleJobDetails
        {
            public string ExampleProperty { get; set; }
            public int AnotherProperty { get; set; }
        }
    }
