    public sealed class AnTrigger : NativeActivity<bool>
    {
        public bool ResultToSet { get; set; }
        protected override void Execute(NativeActivityContext context)
        {
            Result.Set(context, ResultToSet);
        }
    }
