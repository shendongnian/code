class MyClass
{
private bool isDisposed = false;
 
    ~MyClass()
    {
        lock(this)
        {
            if(!isDisposed)
            {
                // ...
            }
        }
    }
}
...
MyClass instance = new MyClass();
Monitor.Enter(instance);
instance = null;
GC.Collect();
GC.WaitForPendingFinalizers();
