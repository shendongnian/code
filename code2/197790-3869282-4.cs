    public class ApprovalWorkflowRunner : IApprovalWorkflowRunner
    {
        private static ILogger Logger { get; set; }
        private static IRepository Repository { get; set; }
    
        public ApprovalWorkflowRunner(ILogger logger, IRepository repository)
        {
            Logger = logger;
            Repository = repository;
        }
    
        public Request Execute(Action action)
        {
            var request = new Request();
    
            var workflowRuntime = WorkflowFactory.GetWorkflowRuntime();
            
    		workflowRuntime.StartRuntime();
    		var waitHandle = new AutoResetEvent(false);
    		WorkflowInstance instance = null;
    		workflowRuntime.WorkflowCompleted += ((sender, e) =>
    												{
    													if (e.WorkflowInstance != instance) return;
    													waitHandle.Set();
    													request = e.OutputParameters["gRequest"] as Request;
    												});
    		workflowRuntime.WorkflowTerminated += ((sender, e) =>
    												{
    													if (e.WorkflowInstance != instance) return;
    													waitHandle.Set();
    													Logger.LogError(e.Exception, true, action.Serialize());
    												});
    
    		var parameters = new Dictionary<string, object>
    							{
    								{"RepositoryInstance", Repository},
    								{"RequestID", action.RequestID.ToString()},
    								{"ActionCode", action.ToString()}
    							};
    
    		instance = workflowRuntime.CreateWorkflow(typeof (ApprovalFlow), parameters);
    		instance.Start();
    		waitHandle.WaitOne();
    
            return request;
        }
    }
