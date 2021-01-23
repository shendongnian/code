    public abstract class JobBase<TDetails>
    {
        protected TDetails Details { get; private set; }
        public JobBase()
        {
            this.Details = this.CreateDetails();
        }
        protected abstract TDetails CreateDetails();
        protected void SaveDetails()
        {
            // Generic save to database.
        }
    }
    public class ExampleJob : JobBase<ExampleJob.ExampleJobDetails>
    {
        public class ExampleJobDetails
        {
            public string ExampleProperty { get; set; }
            public int AnotherProperty { get; set; }
        }
        protected override ExampleJobDetails CreateDetails()
        {
            return new ExampleJobDetails() { ExampleProperty = "Hi.", AnotherProperty = 1 };
        }
    }
