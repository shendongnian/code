    public class DiffeqSolver : Service
    {
        public DiffeqSolver()
        {
            // do any required initialization here
        }
        public ServiceResult Process(ServiceTask task)
        {
            DiffeqTask dtask = task as DiffeqTask;
            if (dtask == null)
            {
                // Error. User didn't pass a DiffeqTask.
                // Somehow communicate error back to client.
            }
            
            // Here, solve the diff eq and return the result.
        }
    }
