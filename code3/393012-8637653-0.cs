    public partial class LoggedContext : MyContext
    {
        public LoggedContext()
            : this("name=MyEntities")    // Adjust this to match your entities
        {
        }
        public LoggedContext(string connectionString)
            : base(EntityConnectionWrapperUtils.CreateEntityConnectionWithWrappers(connectionString)
        {
        }
        private EFTracingConnection TracingConnection
        {
            get { return this.UnwrapConnection<EFTracingConnection>(); }
        }
        public event EventHandler<CommandExecutionEventArgs> CommandExecuting
        {
            add { this.TracingConnection.CommandExecuting += value; }
            remove { this.TracingConnection.CommandExecuting -= value; }
        }
        public event EventHandler<CommandExecutionEventArgs> CommandFinished
        {
            add { this.TracingConnection.CommandFinished += value; }
            remove { this.TracingConnection.CommandFinished -= value; }
        }
        public event EventHandler<CommandExecutionEventArgs> CommandFailed
        {
            add { this.TracingConnection.CommandFailed += value; }
            remove { this.TracingConnection.CommandFailed -= value; }
        }
    }
