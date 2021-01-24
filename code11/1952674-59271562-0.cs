C#
static Task<string> GetToken(...)
{
  var tcs = new TaskCompletionSource<string>();
  try
  {
    ...
    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
    var response = await client.PostAsync(token_url, content);
    var responseString = await response.Content.ReadAsStringAsync();
    return responseString;
  }
  catch (Exception exception)
  {
    return exception.ToString();
  }
}
All `return` statements now become code that sets the result of the TCS:
C#
static Task<string> GetToken(...)
{
  var tcs = new TaskCompletionSource<string>();
  try
  {
    ...
    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
    var response = await client.PostAsync(token_url, content);
    var responseString = await response.Content.ReadAsStringAsync();
    tcs.TrySetResult(responseString);
  }
  catch (Exception exception)
  {
    tcs.TrySetResult(exception.ToString());
  }
}
Next, remove the `try`/`catch` (but remember it's there). With `ContinueWith` we'll need to handle errors within the continuations:
C#
static Task<string> GetToken(...)
{
  var tcs = new TaskCompletionSource<string>();
  ...
  ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
  var response = await client.PostAsync(token_url, content);
  var responseString = await response.Content.ReadAsStringAsync();
  tcs.TrySetResult(responseString);
//  catch (Exception exception)
//  {
//    tcs.TrySetResult(exception.ToString());
//  }
}
Now you can start converting the `await` statements to `ContinueWith`. For each one, move the rest of the method into a continuation. Note that [`ContinueWith` is dangerous][2], so be sure to pass the correct scheduler. This code does not look like it needs the original context, so I'm using `TaskScheduler.Default`. So technically, this is a translation of `await` with `ConfigureAwait(false)` and not just a plain `await`, which would be more complex.
The continuation gets a task, which it can query for exceptions or results. Be aware of which members wrap exceptions in `AggregateException`; that can change your exception handling code.
This is what the first `await` transformation looks like:
C#
static Task<string> GetToken(...)
{
  var tcs = new TaskCompletionSource<string>();
  ...
  ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
  client.PostAsync(token_url, content).ContinueWith(task =>
  {
    if (task.IsFaulted)
    {
      tcs.TrySetResult(task.Exception.InnerException.ToString());
      return;
    }
    var response = task.Result;
    var responseString = await response.Content.ReadAsStringAsync();
    tcs.TrySetResult(responseString);
  }, TaskScheduler.Default);
//  catch (Exception exception)
//  {
//    tcs.TrySetResult(exception.ToString());
//  }
}
The second `await` transformation can be done in a similar way:
C#
static Task<string> GetToken(...)
{
  var tcs = new TaskCompletionSource<string>();
  ...
  ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
  client.PostAsync(token_url, content).ContinueWith(task =>
  {
    if (task.IsFaulted)
    {
      tcs.TrySetResult(task.Exception.InnerException.ToString());
      return;
    }
    var response = task.Result;
    response.Content.ReadAsStringAsync().ContinueWith(task2 =>
    {
      if (task2.IsFaulted)
      {
        tcs.TrySetResult(task2.Exception.InnerException.ToString());
        return;
      }
      var responseString = task2.Result;
      tcs.TrySetResult(responseString);
    }, TaskScheduler.Default);
  }, TaskScheduler.Default);
}
Alternatively, with simple `await` statements one after another, you can "chain" the continuations. You do need to use `Unwrap` since the first continuation returns a task. This approach looks like this:
C#
static Task<string> GetToken(...)
{
  var tcs = new TaskCompletionSource<string>();
  ...
  ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
  client.PostAsync(token_url, content).ContinueWith(task =>
  {
    if (task.IsFaulted)
    {
      tcs.TrySetResult(task.Exception.InnerException.ToString());
      return;
    }
    var response = task.Result;
    return response.Content.ReadAsStringAsync();
  }, TaskScheduler.Default)
  .Unwrap()
  .ContinueWith(task =>
  {
    if (task.IsFaulted)
    {
      tcs.TrySetResult(task.Exception.InnerException.ToString());
      return;
    }
    var responseString = task.Result;
    tcs.TrySetResult(responseString);
  }, TaskScheduler.Default);
}
As a final note, with "chained" continuations, many people prefer to flow the exceptions through and flatten them at the end; the code is a little shorter that way:
C#
static Task<string> GetToken(...)
{
  var tcs = new TaskCompletionSource<string>();
  ...
  ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
  client.PostAsync(token_url, content).ContinueWith(task =>
  {
    var response = task.Result;
    return response.Content.ReadAsStringAsync();
  }, TaskScheduler.Default)
  .Unwrap()
  .ContinueWith(task =>
  {
    if (task.IsFaulted)
    {
      tcs.TrySetResult(task.Exception.Flatten().InnerException.ToString());
      return;
    }
    var responseString = task.Result;
    tcs.TrySetResult(responseString);
  }, TaskScheduler.Default);
}
And that's why developers like the `async` and `await` keywords. ;)
  [1]: https://codeblog.jonskeet.uk/2011/05/08/eduasync-part-1-introduction/
  [2]: https://blog.stephencleary.com/2013/10/continuewith-is-dangerous-too.html
