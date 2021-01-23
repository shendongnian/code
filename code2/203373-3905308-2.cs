    public void OnMessageReceived(QuickFix42.Message message)  
    {  
          QuickFix42.ExecutionReport ExecutionReportMessage = message as QuickFix42.ExecutionReport;
          QuickFix42.AllocationACK  AllocationACKMessage = message as QuickFix42.AllocationACK  ;
          QuickFix42.OrderCancelReject OrderCancelRejectMessage = message as QuickFix42.OrderCancelReject;
     if (ExecutionReportMessage !=null)  
    {  
        ProcessExecutionReport(ExecutionReportMessage);  
    }  
    else if (AllocationACKMessage !=null)  
    {  
        ProcessAllocationAck(AllocationACKMessage );  
    }  
    else if (OrderCancelRejectMessage !=null)  
    {  
        ProcessOrderCancelReject(OrderCancelRejectMessage);  
    }  
    // ...  
} 
