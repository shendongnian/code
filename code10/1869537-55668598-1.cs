        public class CustomLock
        {
            private readonly int[] Running;
            private readonly object _lock;
            public CustomLock(int Count)
            {
                Running = new int[Count];
                _lock = new object();
            }
            public void LockOne(int Task)
            {
                lock (_lock)
                {
                    Running[Task]++;
                }
            }
            public void UnlockOne(int Task)
            {
                lock (_lock)
                {
                    Running[Task]--;
                }
            }
            public bool Locked(int Task)
            {
                lock (_lock)
                {
                    for (int i = 0; i < Running.Length; i++)
                    {
                        if (i != Task && Running[i] != 0)
                            return true;
                    }
                    return false;
                }
            }
        }
2. Change the already existing code.<br>
ChangeState will be task 0, and DoStuff will be task 1.
private CustomLock Lock = new CustomLock(2); //Create a new instance of the class for 2 tasks
async Task ChangeState(bool state)
{
   while (Lock.Locked(0)) //Wait for the task to get unlocked
      await Task.Delay(10);
   Lock.LockOne(0); //Lock this task
   await OutsideApi.ChangeState(state);
   Lock.UnlockOne(0); //Task finished, unlock one
}
async Task DoStuff()
{
   while (Lock.Locked(1))
      await Task.Delay(10);
   Lock.LockOne(1);
   await OutsideApi.DoStuff();
   Lock.UnlockOne(1);
}
While any ChangeState is running a new one can be started without waiting but when a DoStuff is called it will wait untill all ChangeStates finish, and this works the other way too.
