c#
private async IAsyncEnumerable<Item> GetItemAfterDelay(IEnumerable<Item> items)
{
    var e = items.GetEnumerator();
    if (e.MoveNext()){
       var started = DateTime.Now;
       var firstTime = e.Current.Timestamp;
       yield return e.Current;
       while(e.MoveNext()){
          var delay = (e.Current.Timestamp - firstTime) - (DateTime.Now - started);
          if (delay >0)
             await Task.Delay(delay);
          yield return e.Current;
       }
    }
}
await foreach(var item in GetItemAfterDelay(items)){
   // ...
}
