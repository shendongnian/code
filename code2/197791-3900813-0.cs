		public Request Execute(Action action, WorkflowRuntime workflowRuntime) {
				workflowRuntime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(workflowRuntime_WorkflowCompleted);
				workflowRuntime.WorkflowTerminated += new EventHandler<WorkflowTerminatedEventArgs>(workflowRuntime_WorkflowTerminated);
				var parameters = new Dictionary<string, object>
                            {
                                {"RepositoryInstance", Repository},
                                {"RequestID", action.RequestID.ToString()},
                                {"ActionCode", action.ToString()}
                            };
				mWorkflowInstance = workflowRuntime.CreateWorkflow(typeof(ApprovalFlow), parameters);
				mWorkflowInstance.Start();
				mWaitHandle.WaitOne();
			return mRequest;
		}
