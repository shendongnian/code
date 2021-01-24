C#
public async Task RetryAsync(Func<Task> _action, int _ms = 1000, int _counter = 3);
public void Retry(Action _action, int _ms = 1000, int _counter = 3);
which can be called as such:
C#
Retry(() => {
  _newID = myDBFunction();
}, 300);
If you want to *always* put synchronous code on a thread pool, you can add an overload for that, to:
C#
public async Task RetryAsync(Func<Task> _action, int _ms = 1000, int _counter = 3);
public async Task RetryAsync(Action _action, int _ms = 1000, int _counter = 3) =>
    await RetryAsync(() => Task.Run(_action), _ms, _counter);
which can be called as such:
C#
await RetryAsync(() => {
    _newID = myDBFunction();
}, 300);
  [1]: https://github.com/App-vNext/Polly
