    public class tempActivity : NativeActivity
    {
        private Activity Delay { get; set; }
        private Variable<int> Counter { get; set; }
        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            Counter = new Variable<int>();
            Delay = new Delay() { Duration = TimeSpan.FromSeconds(1) };
            metadata.AddImplementationChild(Delay);
            metadata.AddImplementationVariable(Counter);
            base.CacheMetadata(metadata);
        }
        protected override void Execute(NativeActivityContext context)
        {
            OnCompleted(context, null);
        }
        private void OnCompleted(NativeActivityContext context, ActivityInstance completedInstance)
        {
            var counter = Counter.Get(context);
            if (counter < 10 && !context.IsCancellationRequested)
            {
                Console.Write(".");
                Counter.Set(context, counter + 1);
                context.ScheduleActivity(Delay, OnCompleted);
            }
        }
    }
