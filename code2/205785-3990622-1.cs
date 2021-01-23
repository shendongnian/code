    public sealed class AnTriggerHost : NativeActivity, IActivityTemplateFactory
    {
        public ActivityFunc<bool> Condition { get; set; }
        public ActivityAction Child { get; set; }
        protected override void Execute(NativeActivityContext context)
        {
            context.ScheduleFunc(Condition, OnConditionComplete);
        }
        private void OnConditionComplete(
            NativeActivityContext context, 
            ActivityInstance completedInstance, 
            bool result)
        {
            if (result)
                context.ScheduleAction(Child);
        }
        Activity IActivityTemplateFactory.Create(System.Windows.DependencyObject target)
        {
            // so I don't have to create UI for these, here's a couple samples
            // seq is the first child and will run as the first AnTrigger is configured to return true
            // so the first trigger evals to true and the first child runs, which
            var seq = new Sequence
            {
                DisplayName = "Chief Runs After First Trigger Evals True"
            };
            // prints this message to the console and
            seq.Activities.Add(new WriteLine { Text = "See this?  It worked." });
            // runs this second trigger host, which 
            seq.Activities.Add(
                new AnTriggerHost
                {
                    DisplayName = "This is the SECOND host",
                    Condition = new ActivityFunc<bool>
                    {
                        // will NOT be triggered, so you will never see
                        Handler = new AnTrigger
                        {
                            ResultToSet = false,
                            DisplayName = "I return false guize"
                        }
                    },
                    Child = new ActivityAction
                    {
                        // this activity write to the console.
                        Handler = new WriteLine
                        {
                            Text = "you won't see me"
                        }
                    }
                });
            return new AnTriggerHost
            {
                DisplayName = "This is the FIRST host",
                Condition = new ActivityFunc<bool>
                {
                    Handler = new AnTrigger
                    {
                        ResultToSet = true,
                        DisplayName = "I return true!"
                    }
                },
                Child = new ActivityAction
                {
                    Handler = seq
                }
            };
        }
    }
