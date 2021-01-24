C#
public async Task<TestClass> WaitForUserInput(IResource resource, CancellationToken token)
{
  var button = resource.GetResource();
  var taskCompletionSource = new TaskCompletionSource<UserActionResult>();
  IDisposable cancellationTokenReg = token.Register(
                                      () => taskCompletionSource.SetResult(new TestClass()));
  button.TouchEvent += Subscribe;
  button.Disabled = true;
  var result = await taskCompletionSource.Task;
  cancellationTokenReg.Dispose();
  return result;
}
Once you're using `async`/`await`, then you can simplify further by using a `using` declaration:
C#
public async Task<TestClass> WaitForUserInput(IResource resource, CancellationToken token)
{
  var button = resource.GetResource();
  var taskCompletionSource = new TaskCompletionSource<UserActionResult>();
  using var cancellationTokenReg = token.Register(
                                      () => taskCompletionSource.SetResult(new TestClass()));
  button.TouchEvent += Subscribe;
  button.Disabled = true;
  return await taskCompletionSource.Task;
}
