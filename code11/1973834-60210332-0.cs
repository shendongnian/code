    [FunctionName("ApprovalWorkflow")]
    public static async Task Run(
        [OrchestrationTrigger] IDurableOrchestrationContext context)
    {
        await context.CallActivityAsync("RequestApproval", null);
        using (var timeoutCts = new CancellationTokenSource())
        {
            DateTime dueTime = context.CurrentUtcDateTime.AddHours(72);
            Task durableTimeout = context.CreateTimer(dueTime, timeoutCts.Token);
    
            Task<bool> approvalEvent = context.WaitForExternalEvent<bool>("ApprovalEvent");
            if (approvalEvent == await Task.WhenAny(approvalEvent, durableTimeout))
            {
                timeoutCts.Cancel();
                await context.CallActivityAsync("ProcessApproval", approvalEvent.Result);
            }
            else
            {
                await context.CallActivityAsync("Escalate", null);
            }
        }
    }
