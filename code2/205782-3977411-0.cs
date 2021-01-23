    IActivityTemplateFactory factory = new Trigger();
    var trigger = (Trigger)factory.Create(null);
    trigger.Condition.Handler = new AlwaysTrue();
    trigger.Child.Handler = new WriteLine()
    {
        Text = "Its true."
    };
    WorkflowInvoker.Invoke(trigger);
    class AlwaysTrue : CodeActivity<bool>
    {
        protected override bool Execute(CodeActivityContext context)
        {
            return true;
        }
    }
