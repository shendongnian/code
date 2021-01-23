    public sealed class TestArrayActivity : CodeActivity<String[]>
    {
        // Define an activity input argument of type List<string>
        public InArgument<List<string>> StringsList { get; set; }
        protected override string[] Execute(CodeActivityContext context)
        {
            context.GetValue(this.StringsList);
            return new string[2];
        }
        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            metadata.AddArgument(new RuntimeArgument(
            "StringsList", typeof(List<String>), ArgumentDirection.In));
        }
    }
