    public class WorkflowModule : NinjectModule
    {
        #region Overrides of NinjectModule
        public override void Load()
        {
            Bind<IWorkflow>().To<Workflow>();
            Bind<IWorkflowStep>().To<WorkflowStep>();
        }
        #endregion
    }
