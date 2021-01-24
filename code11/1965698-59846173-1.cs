c#
using Polly;
using System;
using System.Net.Http;
using System.Diagnostics;
c#
MyResponse = await Policy.HandleResult<HttpResponseMessage>(message => !message.IsSuccessStatusCode).WaitAndRetryAsync(10, i => TimeSpan.FromSeconds(5), (result, timeSpan, retryCount, context) =>
{
    Debug.WriteLine("Hit Polly Sending Data!");
}).ExecuteAsync(() => myHttpClient.PostAsync(url, myStringContent));
as opposed to this
c#
var MyResponse = await Policy
    .HandleResult<HttpResponseMessage>(
        message => !message.IsSuccessStatusCode)
    .WaitAndRetryAsync(
        10, 
        i => TimeSpan.FromSeconds(5), 
        (result, timeSpan, retryCount, context) => {
            Debug.WriteLine("Hit Polly Sending Data!");
        })
    .ExecuteAsync(
        () => myHttpClient.PostAsync(url, myStringContent));
So Telerik will translate that code into this VB
vb.net
Dim MyResponse = Await Policy.HandleResult(Of HttpResponseMessage)(Function(message) Not message.IsSuccessStatusCode).WaitAndRetryAsync(10, Function(i) TimeSpan.FromSeconds(5), Function(result, timeSpan, retryCount, context)
                                                                                                                                                                                                                                    Debug.WriteLine("Hit Polly Sending Data!")
                                                                                                                                                                                                                                End Function).ExecuteAsync(Function() myHttpClient.PostAsync(url, myStringContent))
Formatted nicely, it is this
vb.net
Dim MyResponse = Await Policy.
    HandleResult(Of HttpResponseMessage)(
        Function(message) Not message.IsSuccessStatusCode
    ).
    WaitAndRetryAsync(
        10,
        Function(i) TimeSpan.FromSeconds(5),
        Function(result, timeSpan, retryCount, context)
            Debug.WriteLine("Hit Polly Sending Data!")
        End Function
    ).
    ExecuteAsync(
        Function() myHttpClient.PostAsync(url, myStringContent
    ))
However, note that there is a warning on the statement `End Function`
> Function '<anonymous method>' doesn't return a value on all code paths. A null reference exception could occur at run time when the result is used.
This is because the translator is not smart enough to select the correct overload of  `WaitAndRetryAsync`. It chose
c#
public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Func<DelegateResult<TResult>, TimeSpan, Context, Task> onRetryAsync);
but it should have chosen
c#
public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, TimeSpan, int, Context> onRetry);
which is passed an Action, instead of Func. *I* know that because you call `Debug.WriteLine` which returns nothing. You'd need to modify that manually, which is simple. Here is the final result, I hope...
vb.net
Dim MyResponse = Await Policy.
    HandleResult(Of HttpResponseMessage)(
        Function(message) Not message.IsSuccessStatusCode
    ).
    WaitAndRetryAsync(
        10,
        Function(i) TimeSpan.FromSeconds(5),
        Sub(result, timeSpan, retryCount, context)
            Debug.WriteLine("Hit Polly Sending Data!")
        End Sub
    ).
    ExecuteAsync(
        Function() myHttpClient.PostAsync(url, myStringContent
    ))
