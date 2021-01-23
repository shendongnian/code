    // Define an interface for the operation
    public interface IMyLongRunningTask
    {
        DBResult longTask(DBCommand command);
    }
    // Define an implementation for the operation:
    public class MyLongRunningTask : IMyLongRunningTask
    {
        public DBResult longTask(DBCommand command)
        {
            // code here
        }
    }
