       public class FilePersistenceService : WorkflowPersistenceService
    {
        public FilePersistenceService(bool unloadOnIdle)
        {
           // ...
        }
        protected override void SaveWorkflowInstanceState(Activity rootActivity, bool unlock)
        {
            // ...
        }
        private void ReloadWorkflow(object id)
        {
            // ...
        }
        protected override Activity LoadWorkflowInstanceState(Guid instanceId)
        {
            // ...
        }
        protected override void UnlockWorkflowInstanceState(Activity state)
        {
            // ...
        }
        protected override void SaveCompletedContextActivity(Activity activity)
        {
            // ...
        }
        protected override Activity LoadCompletedContextActivity(Guid activityId, Activity outerActivity)
        {
            // ...
        }
        protected override bool UnloadOnIdle(Activity activity)
        {
            // ...
        }
        private void SerializeToFile(byte[] workflowBytes, Guid id)
        {
            // ... Direct workflowBytes to DB, indexed by Guid
        }
        private byte[] DeserializeFromFile(Guid id)
        {
            // ... Load bytes from DB, by Guid
        }
    }
