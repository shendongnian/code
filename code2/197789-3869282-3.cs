	public static class WorkflowFactory
	{
		// Singleton instance of the workflow runtime
		private static WorkflowRuntime _workflowRuntime = null;
		// Lock (sync) object
		private static object _syncRoot = new object();
		/// <summary>
		/// Factory method
		/// </summary>
		/// <returns></returns>
		public static WorkflowRuntime GetWorkflowRuntime()
		{
			// Lock execution thread in case of multi-threaded
			// (concurrent) access.
			lock (_syncRoot)
			{
				// Check for startup condition
				if (null == _workflowRuntime)
				{
					// Provide for shutdown
					AppDomain.CurrentDomain.ProcessExit += new EventHandler(StopWorkflowRuntime);
					AppDomain.CurrentDomain.DomainUnload += new EventHandler(StopWorkflowRuntime);
					// Not started, so create instance
					_workflowRuntime = new WorkflowRuntime();
					// Start the runtime
					_workflowRuntime.StartRuntime();
				} // if
				// Return singleton instance
				return _workflowRuntime;
			} // lock
		}
		// Shutdown method
		static void StopWorkflowRuntime(object sender, EventArgs e)
		{
			if (_workflowRuntime != null)
			{
				if (_workflowRuntime.IsStarted)
				{
					try
					{
						// Stop the runtime
						_workflowRuntime.StopRuntime();
					}
					catch (ObjectDisposedException)
					{
						// Already disposed of, so ignore...
					} // catch
				} // if
			} // if
		}
	}
