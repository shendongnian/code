static SemaphoreSlim semaphore = new SemaphoreSlim (3); // Capacity of 3
List&lt;Task&gt; tasks = new List&lt;Task&gt;();
for (int i = 0; i &lt; length; i++) //each iteration in another task
{
     tasks.Add(Task.Factory.StartNew(() =>
     {
         Method2();
     }, 
     TaskCreationOptions.LongRunning);
}
Task.WaitAll(tasks)
public void Method2()
{
    Method3();
}
public void Method3()
{
    Method4();
}
public void Method4()
{
    semaphore.Wait();
    process1.Start(); 
    process1.WaitForExit();
    semaphore.Release();
}
