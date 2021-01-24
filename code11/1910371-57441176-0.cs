    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Security;
    using System.Security.Permissions;
    using System.Threading.Tasks;
    
    [assembly: CompilationRelaxations(8)]
    [assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
    [assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default
        | DebuggableAttribute.DebuggingModes.DisableOptimizations
        | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints
        | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
    [assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
    [assembly: AssemblyVersion("0.0.0.0")]
    [module: UnverifiableCode]
    public class Program
    {
        [CompilerGenerated]
        private sealed class <DoSomethingLong>d__0 : IAsyncStateMachine
        {
            public int <>1__state;
    
            public AsyncTaskMethodBuilder <>t__builder;
    
            private int <i>5__1;
    
            private TaskAwaiter <>u__1;
    
            private void MoveNext()
            {
                int num = <>1__state;
                try
                {
                    TaskAwaiter awaiter;
                    if (num != 0)
                    {
                        awaiter = Task.Delay(10).GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            num = (<>1__state = 0);
                            <>u__1 = awaiter;
                            <DoSomethingLong>d__0 stateMachine = this;
                            <>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
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
                    <i>5__1 = 0;
                    while (<i>5__1 < 1000)
                    {
                        Console.Write("<");
                        <i>5__1++;
                    }
                }
                catch (Exception exception)
                {
                    <>1__state = -2;
                    <>t__builder.SetException(exception);
                    return;
                }
                <>1__state = -2;
                <>t__builder.SetResult();
            }
    
            void IAsyncStateMachine.MoveNext()
            {
                // ILSpy generated this explicit interface implementation from
                // .override directive in MoveNext
                this.MoveNext();
            }
    
            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
    
            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                // ILSpy generated this explicit interface implementation from
                // .override directive in SetStateMachine
                this.SetStateMachine(stateMachine);
            }
        }
    
        [AsyncStateMachine(typeof(<DoSomethingLong>d__0))]
        [DebuggerStepThrough]
        private static Task DoSomethingLong()
        {
            <DoSomethingLong>d__0 stateMachine = new <DoSomethingLong>d__0();
            stateMachine.<>t__builder = AsyncTaskMethodBuilder.Create();
            stateMachine.<>1__state = -1;
            AsyncTaskMethodBuilder <>t__builder = stateMachine.<>t__builder;
            <>t__builder.Start(ref stateMachine);
            return stateMachine.<>t__builder.Task;
        }
    }
