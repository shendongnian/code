    public PostDownloadTriggerListener : ITriggerListener
    {
        string Name { get { return "MyTriggerName"; } }
        void TriggerFired(Trigger trigger, JobExecutionContext context) { }
        bool VetoJobExecution(Trigger trigger, JobExecutionContext context) { }
        void TriggerMisfired(Trigger trigger) { }
        void TriggerComplete(Trigger trigger, JobExecutionContext context, int triggerInstructionCode)
        {
            // Perform processing here
        }
    }
