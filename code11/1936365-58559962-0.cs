public class CommunicationsBlock {
   public AutoResetEvent ValueReady {get; set;}
   public object NewValue {get; set;}
}
(in parent)
var cb = new CommunicationsBlock {
   ValueReady = new AutoResetEvent(false)
};
var child = new Thread(ChildThread);
child.Start(cb);
while (true)
{
   if (cb.ValueReady.WaitOne(TimeSpan.FromMilliseconds(10)))
   {
      // We have a new value
   }
}
(child thread)
private static void ChildThread(object state)
{
   var cb = (CommunicationsBlock) state;
   while (true)
   {
      // some stuff
      if (readytosend)
      {
         cb.NewValue = new object();
         cb.ValueReady.Set();
      }
   }
}
