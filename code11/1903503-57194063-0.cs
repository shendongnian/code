`    
    public struct ActionOnDispose : IDisposable
    {
        public ActionOnDispose(Action action) => this.Action = action;
        private Action Action { get; }
        public void Dispose() => this.Action?.Invoke();
    }
    
    public class StateLock
    {
        private SemaphoreSlim Semaphore { get; } = new SemaphoreSlim(1, 1);
        public bool IsLocked => this.Semaphore.CurrentCount == 0;
        public ActionOnDispose Lock()
        {
            this.Semaphore.Wait();
            return new ActionOnDispose(() => this.Semaphore.Release());
        }
    }
`
The point of the StateLock class is that the only way to use the semaphore is by Wait, and not by WaitAsync. More on this later. Comment: the purpose of ActionOnDispose is to enable statements such as "using (stateLock.Lock()) { … }".
3. Task-level locking for the purpose of preventing re-entry into methods, where within a lock the methods may invoke user callbacks or other code that is outside the class. This would include all cases where there are asynchronous operations within the lock, such as "await" -- when you await, any other Task may run and call back into your method. In this situation a good approach is to use SemaphoreSlim again but with an asynchronous signature. The following class provides some bells and whistles on what is essentially a call to SemaphoreSlim(1,1).WaitAsync(). You use it in a code construct like "using (await methodLock.LockAsync()) { … }". Comment: the purpose of the helper struct is to prevent accidentally omitting the "await" in the using statement.
`
    public class MethodLock : DebugBase
    {
        public MethodLock( string lockName)
        {
            this.LockName = lockName;
        }
        private SemaphoreSlim Semaphore { get; } = new SemaphoreSlim(1, 1);
        public string LockName { get; }
        private int Release() => this.Semaphore.Release();
        public bool IsLocked => this.CurrentCount == 0;
        private async Task<ActionOnDispose> RequestLockAsync()
        {
            await this.Semaphore.WaitAsync().ConfigureAwait(false);
            return new ActionOnDispose( () => this.Release());
        }
        public TaskReturningActionOnDispose LockAsync()
        {
            return new TaskReturningActionOnDispose(this.RequestLockAsync());
        }
    }
`
`
    public struct TaskReturningActionOnDispose
    {
        private Task<ActionOnDispose> TaskResultingInActionOnDispose { get; }
        public TaskReturningActionOnDispose(Task<ActionOnDispose> task)
        {
            if (task == null) { throw new ArgumentNullException("task"); }
            this.TaskResultingInActionOnDispose = task;
        }
        // Here is the key method, that makes it awaitable.
        public TaskAwaiter<ActionOnDispose> GetAwaiter()
        {
            return this.TaskResultingInActionOnDispose.GetAwaiter();
        }
    }
`
4. What you don't want to do is freely mix together both LockAsync() and Lock() on the same SemaphoreSlim. Experience shows that this leads very quickly to a lot of difficult-to-identify deadlocks. On the other hand if you stick to the two classes above you will not have these problems. It is still possible to have deadlocks, for example if within a Lock() you call another class method that also does a Lock(), or if you do a LockAsync() in a method and then the called-back user code tries to re-enter the same method. But preventing those reentry situations is exactly the point of the locks -- deadlocks in these cases are "normal" bugs that represent a logic error in your design and are fairly straightforward to deal with. One tip for this, if you want to easily detect such deadlocks, what you can do is before actually doing the Wait() or WaitAsync() you can first do a preliminary Wait/WaitAsync with a timeout, and if the timeout occurs print a message saying there is likely a deadlock. Obviously you would do this within #if DEBUG / #endif.
5. Another typical locking situation is when you want some of your Task(s) to wait until a condition is set to true by another Task. For example, you may want to wait until the application is initialized. To accomplish this, use a TaskCompletionSource to create a wait flag as shown in the following class. You could also use ManualResetEventSlim but if you do that then it requires disposal, which is not convenient at all.
`
    public class Null { private Null() {} } // a reference type whose only possible value is null. 
    public class WaitFlag
    {
        public WaitFlag()
        {
            this._taskCompletionSource = new TaskCompletionSource<Null>(TaskCreationOptions.RunContinuationsAsynchronously);
        }
        public WaitFlag( bool value): this()
        {
            this.Value = value;
        }
        private volatile TaskCompletionSource<Null> _taskCompletionSource;
        public static implicit operator bool(WaitFlag waitFlag) => waitFlag.Value;
        public override string ToString() => ((bool)this).ToString();
        public async Task WaitAsync()
        {
            Task waitTask = this._taskCompletionSource.Task;
            await waitTask;
        }
        public void Set() => this.Value = true;
        public void Reset() => this.Value = false;
        public bool Value {
            get {
                return this._taskCompletionSource.Task.IsCompleted;
            }
            set {
                if (value) { // set
                    this._taskCompletionSource.TrySetResult(null);
                } else { // reset
                    var tcs = this._taskCompletionSource;
                    if (tcs.Task.IsCompleted) {
                        bool didReset = (tcs == Interlocked.CompareExchange(ref this._taskCompletionSource, new TaskCompletionSource<Null>(TaskCreationOptions.RunContinuationsAsynchronously), tcs));
                        Debug.Assert(didReset);
                    }
                }
            }
        }
    }
`
6. Lastly, when you want to atomically test and set a flag. This is useful when you want to execute an operation only if it is not already being executed. You could use the StateLock to do this. However a lighter-weight solution for this specific situation is to use the Interlocked class. Personally I find Interlocked code is confusing to read because I can never remember which parameter is being tested and which is being set. To make it into a TestAndSet operation: 
`
    public class InterlockedBoolean
    {
        private int _flag; // 0 means false, 1 means true
        // Sets the flag if it was not already set, and returns the value that the flag had before the operation.
        public bool TestAndSet()
        {
            int ifEqualTo = 0;
            int thenAssignValue = 1;
            int oldValue = Interlocked.CompareExchange(ref this._flag, thenAssignValue, ifEqualTo);
            return oldValue == 1;
        }
        public void Unset()
        {
            int ifEqualTo = 1;
            int thenAssignValue = 0;
            int oldValue = Interlocked.CompareExchange(ref this._flag, thenAssignValue, ifEqualTo);
            if (oldValue != 1) { throw new InvalidOperationException("Flag was already unset."); }
        }
    }
`
I would like to say that none of the code above is brilliantly original. There are many antecedents to all of them which you can find by searching enough on the internet. 
