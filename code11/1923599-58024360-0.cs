    public class GetServerIdFilter : IApplyStateFilter
    {
        public void OnStateApplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
            var state = context.NewState as ProcessingState;
            if (state != null)
            {
                var serverId = state.ServerId;
                var workerId = state.WorkerId;
            }
        }
        public void OnStateUnapplied(ApplyStateContext context, IWriteOnlyTransaction transaction)
        {
        }
    }
