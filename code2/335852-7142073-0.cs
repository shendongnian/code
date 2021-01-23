class WorkflowAppAdapter
    {
        private HttpContext m_Context;
        private WorkflowApplication m_WorkflowApp;
        public WorkflowAppAdapter(WorkflowApplication app, HttpContext context)
        {
            m_Context = context;
            m_WorkflowApp = app;
            app.Completed =
                (e) =>
                {
                    Debug.WriteLine(m_Context.Request.Browser.Browser);
                };
        }
        public void Run()
        {
            m_WorkflowApp.Run();
        }
    }
