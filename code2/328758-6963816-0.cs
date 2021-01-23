try
{
lock.EnterWriteLock(); //ReadLock
//Your code here, which can possibly throw an exception.
}
finally
{
lock.ExitWriteLock(); //ReadLock
}
