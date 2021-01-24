IAsyncEnumerable<T> ToAsyncEnumerable<T>(IEnumerable<Task<T>> inputTasks)
{
    var channel=Channel.CreateUnbounded<T>();
    var writer=channel.Writer;
    var continuations=inputTasks.Select(t=>t.ContinueWith(x=>
                                           writer.TryWrite(x.Result)));
    _ = Task.WhenAll(continuations)
            .ContinueWith(_=>writer.Complete());
    return channel.Reader.ReadAllAsync();
}
When all tasks complete `writer.Complete()` is called to close the channel.
To test this, this code produces tasks with decreasing delays. This should return the indexes in reverse order :
    var tasks=Enumerable.Range(1,4)
                        .Select(async i=>
                        { 
                          await Task.Delay(300*(5-i));
                          return i;
                        });
    
    await foreach(var i in Interleave(tasks))
    {
         Console.WriteLine(i);
         
    }
Produces :
4
3
2
1
