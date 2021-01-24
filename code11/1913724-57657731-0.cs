csharp
var queue = new AsyncProducerConsumerQueue<int>();
// This is a cold observable, so each observer is fed by its own individual dequeue loop
// and therefore will be 'competing' with other observers for queued items.
var coldObservable = Observable
    // Create an observable that asynchronously waits for items to become available on the
    // queue and then emits them to the observer.
    .Create<int>(async observer =>
    {
        while (true)
        {
            var item = await queue.DequeueAsync().ConfigureAwait(false);
            Console.WriteLine($"Dequeued {item}");
            observer.OnNext(item);
        }
    })
    // If an InvalidOperationException is thrown by the above, continue with
    // an empty observable instead of the error. This effectively catches an
    // `OnError(InvalidOperationException)` and turns it into an `OnCompleted()`.
    .Catch<int, InvalidOperationException>(exn =>
    {
        Console.WriteLine("Caught InvalidOperation");
        return Observable.Empty<int>();
    });
Console.WriteLine("TEST COLD");
await queue.EnqueueAsync(1);
Console.WriteLine("Enqueued 1");
Console.WriteLine("Subscribing A");
coldObservable.Subscribe(
    item => Console.WriteLine($"A received {item}"),
    () => Console.WriteLine("A completed"));
Console.WriteLine("Subscribing B");
coldObservable.Subscribe(
    item => Console.WriteLine($"B received {item}"),
    () => Console.WriteLine("B completed"));
await queue.EnqueueAsync(2);
Console.WriteLine("Enqueued 2");
await queue.EnqueueAsync(3);
Console.WriteLine("Enqueued 3");
queue.CompleteAdding();
Console.WriteLine("Completed adding");
Console.WriteLine("Waiting...");
await Task.Delay(2000);
Console.WriteLine("DONE");
// TEST COLD
// Enqueued 1
// Subscribing A
// Dequeued 1
// A received 1
// Subscribing B
// Enqueued 2
// Enqueued 3
// Completed adding
// Waiting...
// Dequeued 2
// Dequeued 3
// A received 2
// B received 3
// Caught InvalidOperation
// Caught InvalidOperation
// A completed
// B completed
// DONE
# Demo #2 - Hot observable
csharp
var queue = new AsyncProducerConsumerQueue<int>();
var coldObservable = // defined same as above
// This is a hot observable, so each observer receives the same items from the queue.
var hotObservable = coldObservable
    // Publish the cold observable to create an `IConnectableObservable` that will subscribe
    // to the dequeue loop when connected and emit the same items to all observers.
    .Publish()
    // Automatically connect to the published observable when the first observer subscribes
    // and automatically disconnect when the last observer unsubscribes. This means that the
    // first observer will receive any items queued before it subscribes, but additional
    // observers will only receive items queued after they subscribed.
    .RefCount();
Console.WriteLine("TEST HOT");
await queue.EnqueueAsync(1);
Console.WriteLine("Enqueued 1");
Console.WriteLine("Subscribing A");
hotObservable.Subscribe(
    item => Console.WriteLine($"A received {item}"),
    () => Console.WriteLine("A completed"));
Console.WriteLine("Subscribing B");
hotObservable.Subscribe(
    item => Console.WriteLine($"B received {item}"),
    () => Console.WriteLine("B completed"));
await queue.EnqueueAsync(2);
Console.WriteLine("Enqueued 2");
await queue.EnqueueAsync(3);
Console.WriteLine("Enqueued 3");
queue.CompleteAdding();
Console.WriteLine("Completed adding");
Console.WriteLine("Waiting...");
await Task.Delay(2000);
Console.WriteLine("DONE");
// TEST HOT
// Enqueued 1
// Subscribing A
// Dequeued 1
// A received 1
// Subscribing B
// Enqueued 2
// Enqueued 3
// Dequeued 2
// Completed adding
// Waiting...
// A received 2
// B received 2
// Dequeued 3
// A received 3
// B received 3
// Caught InvalidOperation
// A completed
// B completed
// DONE
To answer your original questions:
>Could it have been written without a wrapper class?
Yes, see demos above.
>Would it be possible to prevent errors from multiple wrappers being applied to one queue?
The approaches demo-ed above do not prevent other parties from dequeueing items (or performing any other operation on the queue). If you want ensure you only expose a single `IObservable<T>` for a given queue, consider encapsulating the queue itself, by creating an `ObservableProducerConsumerQueue<T>` that internally creates and manages its own `AsyncProducerConsumerQueue`. You can expose an `EnqueueAsync` method that just delegates to the internal queue and use one of the demo-ed observables above to either expose the observable as a property or implement the `IObservable<T>` interface.
>Could I make it connect on the first subscription instead of via a direct call to Connect? If so, what are the implications of that?
Demo #2 shows this behaviour and describes the implications. If you want to be able to subscribe observers before connecting, skip the `RefCount` call and use the `IConnectableObservable` returned by `Publish` as before.
>Finally, how would you have done it?
As described above, I would have encapsulated the queue and exposed an `IObservable` or `IConnectableObservable` using one of the approaches demo-ed above.
