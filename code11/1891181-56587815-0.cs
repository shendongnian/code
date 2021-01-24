    [AsyncStateMachine(typeof(<Awaited>d__0))]
    public Task<Guid> Awaited()
    {
        <Awaited>d__0 stateMachine = default(<Awaited>d__0);
        stateMachine.<>t__builder = AsyncTaskMethodBuilder<Guid>.Create();
        stateMachine.<>1__state = -1;
        AsyncTaskMethodBuilder<Guid> <>t__builder = stateMachine.<>t__builder;
        <>t__builder.Start(ref stateMachine);
        return stateMachine.<>t__builder.Task;
    }
    [StructLayout(LayoutKind.Auto)]
    [CompilerGenerated]
    private struct <Awaited>d__0 : IAsyncStateMachine
    {
        public int <>1__state;
        public AsyncTaskMethodBuilder<Guid> <>t__builder;
        private Account <account>5__2;
        private TaskAwaiter <>u__1;
        private void MoveNext()
        {
            int num = <>1__state;
            Guid id;
            try
            {
                TaskAwaiter awaiter;
                if (num != 0)
                {
                    <account>5__2 = new Account();
                    Context.Accounts.Add(<account>5__2);
                    awaiter = Context.SaveChangesAsync().GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        num = (<>1__state = 0);
                        <>u__1 = awaiter;
                        <>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
                        return;
                    }
                }
                else
                {
                    awaiter = <>u__1;
                    <>u__1 = default(TaskAwaiter);
                    num = (<>1__state = -1);
                }
                awaiter.GetResult();
                id = <account>5__2.Id;
            }
            catch (Exception exception)
            {
                <>1__state = -2;
                <>t__builder.SetException(exception);
                return;
            }
            <>1__state = -2;
            <>t__builder.SetResult(id);
        }
        void IAsyncStateMachine.MoveNext()
        {
            //ILSpy generated this explicit interface implementation from .override directive in MoveNext
            this.MoveNext();
        }
        [DebuggerHidden]
        private void SetStateMachine(IAsyncStateMachine stateMachine)
        {
            <>t__builder.SetStateMachine(stateMachine);
        }
        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
            //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
            this.SetStateMachine(stateMachine);
        }
    }
