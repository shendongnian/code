    public void OnMessageReceived(QuickFix42.Message message)
    {
        QuickFix42.ExecutionReport executionReport;
        QuickFix42.AllocationACK allocationAck;
        QuickFix42.OrderCancelReject orderCancelReject;
        if ((executionReport = message as QuickFix42.ExecutionReport) != null)
        {
            ProcessExecutionReport(executionReport);
        }
        else if ((allocationAck = message as QuickFix42.AllocationACK) != null)
        {
            ProcessAllocationAck(allocationAck);
        }
        else if ((orderCancelReject = message as QuickFix42.OrderCancelReject) != null)
        {
            ProcessOrderCancelReject(orderCancelReject);
        }
        // ...
    }
