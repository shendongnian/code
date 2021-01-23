class MyDisposableClass
{
  SomeDisposableThing myThing;
  MyDisposableClass() // Constructor
  {
    bool ok = false;
    try
    {
      myThing = new SomeDisposableThing();
      ... do some other stuff
      ok = true;
    }
    finally
    {
      if (!ok)
      {
        zap(ref myThing);
      }
    }
  }
  static void zap&lt;T&gt;(ref T thing) where T:IDisposable,class
  {
    T oldValue = System.Threading.Interlocked.Exchange(thing, null);
    if (oldValue != null)
      oldValue.Dispose();
  }
}
