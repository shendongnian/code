    public void OnMessageReceived(QuickFix42.Message message)
    {
        ExecuteOnlyAs<QuickFix42.ExecutionReport>(message, ProcessExecutionReport);
        ExecuteOnlyAs<QuickFix42.AllocationACK>(message, ProcessAllocationAck);
        ExecuteOnlyAs<QuickFix42.OrderCancelReject>(message, ProcessOrderCancelReject);
    }
    
    private void ExecuteOnlyAs<T>(QuickFix42.Message message, Action<T> action)
    {
        var t = message as T;
        if (t != null)
        {
            action(t);
        }
    }
