public void CallLocked(Action method)
{
  if (method != null)
    lock (LockObject)
      method();
}
Usage:
    CallLocked(Wrapper.DeleteAllSequences);
