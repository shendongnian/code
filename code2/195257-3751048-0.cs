    public interface IExecutable
    {
        void Execute(IConnection connection);
    }
    public interface IExecutable<TResult> : IExecutable
    {
        TResult Result { get; }
    }
    public abstract ActionBase<TResult> : IExecutable<TResult>
    {
        protected void AddParameter(....);
        protected IDataReader ExecuteAsReader(string query) {
            //create a DB Command, open transaction if needed, execute query, return a reader.
        }
        
        protected object ExecuteAsScalar(string query) {
            //....
        }
        //the concrete implementation
        protected abstract TResult ExecuteInternal();
        IExecutable.Execute(IConnection connection) {
            //keep the connection
            this.Result = ExecuteInternal();
        }
        //another common logic: 
        
    }
