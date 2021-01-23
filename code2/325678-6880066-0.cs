    Public class TaskViewFactory : ITaskViewFactory
    {
         Private IKernel kernel;
         Public TaskViewFactory(IKernel kernel)
         {
             this.kernel = kernel;
         }
         public TaskViewModel CreateTaskViewModel(int taskId)
         {
             this.kernel.Get<ITaskViewModel>(new ConstructorArgument("TaskId", taskId);
         }
     }
